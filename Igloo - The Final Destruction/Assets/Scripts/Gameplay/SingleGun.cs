using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleGun : RangedWeapon
{
    public override void Initialize()
    {
        ammoInClip = clipSize;
    }

    public override void PollShoot()
    {
        if (ammoInClip == 0)
            return;

        if (Input.GetButtonDown("Fire"))
        {
            SpawnShot();
            ammoInClip--;
        }
    }
}
