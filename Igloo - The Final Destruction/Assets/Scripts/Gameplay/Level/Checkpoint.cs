using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {

    private LevelManager levelManager;
    private bool isTriggered = false;

    private Animator animator;

    private void Awake()
    {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isTriggered)
            return;

        if(collision.CompareTag("Player"))
        {
            levelManager.SetCheckpoint(transform);
            isTriggered = true;

            animator.SetTrigger("Trigger");
        }
    }
}
