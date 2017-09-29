using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Health : MonoBehaviour
{
    public int MAX_HP;
    protected int currentHP;

    public GameObject DeathParticles;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        HandleCollisions(collision);
    }

    public abstract void TakeDamage(int damage);

    public abstract void Kill();

    public abstract void HandleCollisions(Collision2D other);
}
