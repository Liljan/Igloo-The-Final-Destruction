using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public CameraFollowBox camera;

    public GameObject PlayerPrefab;
    private GameObject player;

    public int lives;
    private int tokens;

    public Transform startpoint;
    private Transform currentCheckpoint;

    public static LevelManager instance;

    private void Awake()
    {

        instance = this;
    }

    public static LevelManager Instance()
    {
        return instance;
    }

    // Use this for initialization
    private void Start()
    {
        PauseManager.Instance().SetPaused(false);

        SetCheckpoint(startpoint);
        SpawnPlayer();
        HUDManager.Instance().SetLives(lives);

        tokens = 0;
        HUDManager.Instance().SetTokens(tokens);
    }

    private void SpawnPlayer()
    {
        player = Instantiate(PlayerPrefab, currentCheckpoint.position, Quaternion.identity);

        Transform playerTransform = player.GetComponentInChildren<PlayerMovement>().transform;

        camera.SetTarget(playerTransform);
    }

    public void RespawnPlayer()
    {
        if (lives <= 0)
        {
            Debug.Log("Game Över!");
            return;
        }

        SpawnPlayer();
        lives--;

        HUDManager.Instance().SetLives(lives);
    }

    public void SetCheckpoint(Transform t)
    {
        currentCheckpoint = t;
    }

    public void AddLife()
    {
        lives++;

        if (lives >= 0)
            HUDManager.Instance().SetLives(lives);
    }

    public void AddToken(int value)
    {
        tokens += value;
        HUDManager.Instance().SetTokens(tokens);
    }

    public void SetWin()
    {
        Debug.Log("Orn");
    }

    public void SetLose()
    {

    }
}
