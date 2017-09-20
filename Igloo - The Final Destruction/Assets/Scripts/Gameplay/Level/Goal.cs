using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour {

    private LevelManager levelManager;
    private bool isTriggered = false;

    private void Awake()
    {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isTriggered)
            return;

        if (collision.CompareTag("Player"))
        {
            levelManager.SetWin();
            isTriggered = true;
        }
    }
}
