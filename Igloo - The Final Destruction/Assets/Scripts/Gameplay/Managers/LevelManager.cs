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

    public Transform startpoint;
    private Transform currentCheckpoint;

    // Use this for initialization
    void Start()
    {
        SetCheckpoint(startpoint);
        SpawnPlayer();
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


    public void SetWin()
    {

    }

    public void SetLose()
    {

    }
}
