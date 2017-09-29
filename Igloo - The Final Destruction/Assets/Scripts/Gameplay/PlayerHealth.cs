using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health
{
    private bool isDead = false;
    private HUDManager HUD_MANAGER;

    public void Awake()
    {
        currentHP = MAX_HP;

        HUD_MANAGER = GameObject.FindObjectOfType<HUDManager>();
        HUD_MANAGER.SetHealth(currentHP);
    }

    public override void HandleCollisions(Collision2D other)
    {
        string tag = other.transform.tag;

        if (tag.Equals("Enemy"))
        {
            TakeDamage(1);
        }
    }

    public void AddHealth(int health)
    {
        currentHP += health;
        currentHP = Mathf.Clamp(currentHP, 0, MAX_HP);

        HUD_MANAGER.SetHealth(currentHP);
    }

    public override void Kill()
    {
        Instantiate(DeathParticles, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }

    public override void TakeDamage(int damage)
    {
        currentHP -= damage;

        if(currentHP >= 0)
            HUD_MANAGER.SetHealth(currentHP);
        else
            HUD_MANAGER.SetHealth(0);

        if (currentHP <= 0)
            Kill();
    }
}
