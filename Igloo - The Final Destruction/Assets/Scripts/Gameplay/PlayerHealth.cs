using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health
{
    private bool isDead = false;

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
        Instantiate(DeathParticles, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
