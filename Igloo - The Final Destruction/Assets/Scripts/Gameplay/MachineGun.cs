using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGun : RangedWeapon {

    public float fireRate;
    private float fireTime;
    private float fireTimer = 0.0f;

    public override void Initialize()
    {
        ammoInClip = clipSize;

        fireTime = 1F / fireRate;
    }

    public override void PollShoot()
    {
        throw new NotImplementedException();
    }

}
