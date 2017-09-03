using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    public float velocityToAdd;

    private Animator animator;
    private Vector3 direction;

    public void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Use this for initialization
    void Start()
    {
        direction = transform.up;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        string tag = collision.tag;

        if (tag.Equals("Player") || tag.Equals("Enemy"))
        {
            animator.SetTrigger("Jump");

            Rigidbody2D rb2d = collision.GetComponent<Rigidbody2D>();
            rb2d.velocity = velocityToAdd * direction;
        }
    }
}
