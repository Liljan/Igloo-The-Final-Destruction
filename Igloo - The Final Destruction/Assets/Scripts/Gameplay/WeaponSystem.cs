using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSystem : MonoBehaviour
{
    public GameObject[] weapons;

    private int activeWeapon = 0;
    private bool dpadIsPressedDown = false;

    private void Awake()
    {
    }

    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            //GameObject go = Instantiate(startingWeapons[i], transform.position, transform.rotation, this.transform);
            weapons[i].SetActive(false);
        }

        weapons[0].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        HandleWeaponChange();
    }

    private void HandleWeaponChange()
    {
        float dpadX = Input.GetAxis("Toggle_Weapon_X");

        if (dpadX == 0.0f)
        {
            dpadIsPressedDown = false;
            return;
        }

        if (dpadIsPressedDown)
            return;

        if (dpadX == 1.0f)
            ToggleWeaponForward();
        else if (dpadX == -1.0f)
            ToggleWeaponBackward();

        dpadIsPressedDown = true;
    }

    private void ToggleWeaponForward()
    {
        weapons[activeWeapon].SetActive(false);

        if (activeWeapon < weapons.Length - 1)
        {
            activeWeapon++;
        }
        else
        {
            activeWeapon = 0;
        }

        weapons[activeWeapon].SetActive(true);
    }

    private void ToggleWeaponBackward()
    {
        weapons[activeWeapon].SetActive(false);

        if (activeWeapon > 0)
        {
            activeWeapon--;
        }
        else
        {
            activeWeapon = weapons.Length - 1;
        }

        weapons[activeWeapon].SetActive(true);
    }
}
