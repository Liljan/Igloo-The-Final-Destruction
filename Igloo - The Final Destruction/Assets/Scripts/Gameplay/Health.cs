using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Health : MonoBehaviour
{
    public int MAX_HP;
    protected int currentHP;

    public GameObject DeathParticles;

    // For debug text
    protected Camera camera;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        HandleCollisions(collision);
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;

        if (currentHP <= 0)
            Kill();
    }

    public abstract void Kill();

    public abstract void HandleCollisions(Collision2D other);
}
