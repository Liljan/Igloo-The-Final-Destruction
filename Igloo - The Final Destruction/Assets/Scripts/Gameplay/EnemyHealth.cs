using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
{
    private SpriteRenderer spriteRenderer;
    private Collider2D collider2d;
    private Animator animator;

    private bool isDead = false;

    public void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        collider2d = GetComponent<Collider2D>();

        camera = GameObject.FindObjectOfType<Camera>();

        currentHP = MAX_HP;
    }

    public override void HandleCollisions(Collision2D other)
    {
        string tag = other.transform.tag;

        if (tag.Equals("Player"))
        {
            TakeDamage(10);
        }
    }

    public override void Kill()
    {
        if (isDead)
            return;

        Instantiate(DeathParticles, transform.position, Quaternion.identity);

        collider2d.isTrigger = true;
        spriteRenderer.flipY = true;

        isDead = true;
        animator.SetBool("Dead", true);
        Destroy(this.gameObject, 2.0f);
    }

    public void OnGUI()
    {
        Vector3 screenCoords = camera.WorldToScreenPoint(new Vector3(transform.position.x, -transform.position.y - 1.0f, 1.0f));
        GUI.Label(new Rect(screenCoords.x, screenCoords.y, 100, 20), currentHP + " / " + MAX_HP);
    }
}
