﻿using System;
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
    }

    public override void TakeDamage(int damage)
    {
        currentHP -= damage;

        if (currentHP <= 0)
            Kill();
    }

    /*private void OnBecameInvisible()
    {
        if (!isDead)
            return;

        Destroy(gameObject);
    }*/
}
