using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RangedWeapon : MonoBehaviour
{
    protected Transform root;

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
    protected bool isReloading = false;

    public float RELOAD_TIME = 0.5f;
    protected float currentReloadTime;

    // Shell casings
    [Header("Shell casings")]
    public bool shouldDropShells = true;
    public GameObject SHELL;

    // SOUND EFFECTS
    /* [Header("Sound Effects")]
     protected AudioSource audioSource;
     public AudioClip SFX_SHOOT;
     public AudioClip SFX_RELOAD;*/

    protected void Awake()
    {
        //audioSource = GetComponent<AudioSource>();  
    }

    // Use this for initialization
    public void Start()
    {
        root = transform.parent.GetComponentInParent<ArmAim>().parentTransform;
        Initialize();
    }

    public abstract void Initialize();

    public void Update()
    {
        PollShoot();
    }

    // Update is called once per frame
    public abstract void PollShoot();

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
    }
}
