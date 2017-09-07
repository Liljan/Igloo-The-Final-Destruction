using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RangedWeapon : MonoBehaviour
{
    public Transform root;

    public Transform[] firePoints;
    public GameObject Bullet;

    // Weapon stats
    public int damage;
    public float speed;

    protected float recoil = 0.0f;
    public float recoilDegrees = 4.0f;

    [Header("Ammo")]
    public int ammo;
    public int clipSize;
    protected int ammoInClip;

    [Header("Reload")]
    //private FillBar reloadBar;
    public GameObject UI_RELOAD_HINT;
    public FillBar UI_RELOAD_BAR;
    protected bool isReloading = false;

    public float RELOAD_TIME = 0.5f;
    protected float currentReloadTime = 0.0f;

    // Shell casings
    [Header("Shell casings")]
    public bool shouldDropShells = true;
    public GameObject SHELL;
    public Transform shellSpawnPoint;

    // Muzzle flash
    public GameObject MuzzleFlash;
    private SpriteRenderer muzzleFlashRenderer;

    // SOUND EFFECTS
    /* [Header("Sound Effects")]
     protected AudioSource audioSource;
     public AudioClip SFX_SHOOT;
     public AudioClip SFX_RELOAD;*/

    protected void Awake()
    {
        //audioSource = GetComponent<AudioSource>();  
        muzzleFlashRenderer = MuzzleFlash.GetComponent<SpriteRenderer>();
    }

    // Use this for initialization
    public void Start()
    {
        //root = transform.parent.GetComponentInParent<ArmAim>().parentTransform;
        Initialize();

        UI_RELOAD_HINT.SetActive(false);
        UI_RELOAD_BAR.SetEnabled(false);

        MuzzleFlash.SetActive(false);
    }

    public abstract void Initialize();

    public void Update()
    {
        if (isReloading)
        {
            currentReloadTime += Time.deltaTime;
            UI_RELOAD_BAR.SetValue(currentReloadTime / RELOAD_TIME);
        }

        if (!isReloading)
        {
            PollShoot();
            PollReload();
        }
    }

    // Update is called once per frame
    public abstract void PollShoot();

    public void PollReload()
    {
        if (ammoInClip == clipSize)
            return;

        if (ammo == 0)
            return;

        if (Input.GetButtonDown("Reload"))
        {
            StartCoroutine(Reload());
        }
    }

    public IEnumerator Reload()
    {
        isReloading = true;
        UI_RELOAD_BAR.SetEnabled(true);
        UI_RELOAD_BAR.SetValue(0.0f);

        yield return new WaitForSeconds(RELOAD_TIME);
        isReloading = false;
        UI_RELOAD_BAR.SetEnabled(false);
        currentReloadTime = 0.0f;

        // Transfering ammo to mag
        ammo += ammoInClip;

        if (ammo >= clipSize)
        {
            ammo -= clipSize;
            ammoInClip = clipSize;
        }
        else
        {
            ammoInClip = ammo;
            ammo = 0;
        }
    }

    protected void SpawnShot()
    {
        //Quaternion rotation = transform.rotation * Quaternion.Euler(0F, 0F, recoil);
        //recoil += recoilFactor;

        for (int i = 0; i < firePoints.Length; i++)
        {
            GameObject go = Instantiate(Bullet, firePoints[i].position, firePoints[i].rotation * Quaternion.Euler(0F, 0F, root.localScale.x < 0F ? 180F : 0F));
            Bullet bullet = go.GetComponent<Bullet>();

            bullet.SetSpeed(speed);
            bullet.SetDamage(damage);
        }

        if (shouldDropShells)
        {
            GameObject obj = Instantiate(SHELL, shellSpawnPoint.position, shellSpawnPoint.rotation);
            float localRotation = transform.rotation.eulerAngles.z;
        }

        StartCoroutine(ShowMuzzleFlash(0.05f));

        //obj.GetComponent<Rigidbody2D>().velocity = ;
    }

    public IEnumerator ShowMuzzleFlash(float time)
    {
        MuzzleFlash.SetActive(true);
        float x = Random.Range(0.95f, 1.05f);
        float y = Random.Range(0.95f, 1.05f);
        MuzzleFlash.transform.localScale = new Vector3(x, y, 1.0f);
        muzzleFlashRenderer.flipY = Random.value > 0.5f;

        yield return new WaitForSeconds(time);

        MuzzleFlash.SetActive(false);
    }
}
