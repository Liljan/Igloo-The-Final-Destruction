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
    }

    public void SetCheckpoint(Transform t)
    {
        currentCheckpoint = t;
    }

    public void AddLife()
    {
        lives++;
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
