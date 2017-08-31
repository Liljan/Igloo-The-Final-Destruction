using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health
{

    public void Awake()
    {
        currentHP = MAX_HP;
    }

    public override void HandleCollisions(Collision2D other)
    {
        string tag = other.transform.tag;

        if (tag.Equals("Enemy"))
        {
            TakeDamage(1);
        }
    }

    public override void Kill()
    {

    }
}
