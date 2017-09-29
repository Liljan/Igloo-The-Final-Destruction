using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    //private HUDManager HUD_MANAGER;
    private PauseManager PAUSE_MANAGER;

    public CameraFollowBox camera;

    public GameObject PlayerPrefab;
    private GameObject player;

    public int lives;
    private int tokens;

    public Transform startpoint;
    private Transform currentCheckpoint;

    private void Awake()
    {
        //HUD_MANAGER = GameObject.FindObjectOfType<HUDManager>();

        PAUSE_MANAGER = GetComponent<PauseManager>();
        PAUSE_MANAGER.SetPaused(false);
    }

    public void Update()
    {

    }

    // Use this for initialization
    void Start()
    {
        SetCheckpoint(startpoint);
        SpawnPlayer();

        tokens = 0;
    }

    private void SpawnPlayer()
    {
        player = Instantiate(PlayerPrefab, currentCheckpoint.position, Quaternion.identity);

        Transform playerTransform = player.GetComponentInChildren<PlayerMovement>().transform;

        camera.SetTarget(playerTransform);
    }

    public void RespawnPlayer()
    {
        SpawnPlayer();
        lives--;

        HUDManager.Instance().SetLives(lives);

        //if (lives >= 0)
        //HUD_MANAGER.SetLives(lives);
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
        //HUD_MANAGER.SetLives(lives);
    }

    public void AddToken(int value)
    {
        tokens += value;
        Debug.Log(tokens + " Tokens");
    }


    public void SetWin()
    {
        Debug.Log("Orn");
    }

    public void SetLose()
    {

    }
}
