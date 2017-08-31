using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Health : MonoBehaviour
{
    public int MAX_HP;
    protected int currentHP;

    public GameObject DeathParticles;

    void OnGUI()
    {
        GUI.Label(new Rect(transform.position.x, transform.position.y + 1.0f, 100, 20), currentHP + " / " + MAX_HP);
    }

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

    public void Kill()
    {
        Instantiate(DeathParticles, transform.position, Quaternion.identity);
        Destroy(this);
    }

    public abstract void HandleCollisions(Collision2D other);
}
