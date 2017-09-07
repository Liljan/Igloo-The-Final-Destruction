using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGun : RangedWeapon
{
    public float fireRate;
    private float fireTime;
    private float currentFireTime;

    public override void Initialize()
    {
        ammoInClip = clipSize;

        fireTime = 1F / fireRate;
        currentFireTime = fireTime;
    }

    public override void PollShoot()
    {
        currentFireTime += Time.deltaTime;

        if (ammoInClip == 0)
            return;

        if (Input.GetButton("Fire") && currentFireTime >= fireTime)
        {
            SpawnShot();
            ammoInClip--;

            currentFireTime = 0.0f;
        }
    }

}
