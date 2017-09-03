using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health
{
    private bool isDead = false;

    public void Awake()
    {
        camera = GameObject.FindObjectOfType<Camera>();

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

    public void OnGUI()
    {
        Vector3 screenCoords = camera.WorldToScreenPoint(new Vector3(transform.position.x, -transform.position.y - 1.0f, 1.0f));
        GUI.Label(new Rect(screenCoords.x, screenCoords.y, 100, 20), currentHP + " / " + MAX_HP);
    }
}
