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

        HUDManager.Instance().SetHealth(currentHP);
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

        HUDManager.Instance().SetHealth(currentHP);
    }

    public override void Kill()
    {
        Instantiate(DeathParticles, transform.position, Quaternion.identity);
        LevelManager.Instance().RespawnPlayer();

        Destroy(this.gameObject);
    }

    public override void TakeDamage(int damage)
    {
        currentHP -= damage;

        if(currentHP >= 0)
            HUDManager.Instance().SetHealth(currentHP);
        else
            HUDManager.Instance().SetHealth(0);

        if (currentHP <= 0)
            Kill();
    }
}
