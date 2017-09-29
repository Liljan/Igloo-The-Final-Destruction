using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    private bool isTriggered = false;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isTriggered)
            return;

        if (collision.CompareTag("Player"))
        {
            LevelManager.Instance().SetWin();
            isTriggered = true;

            animator.SetTrigger("Trigger");
        }
    }
}
