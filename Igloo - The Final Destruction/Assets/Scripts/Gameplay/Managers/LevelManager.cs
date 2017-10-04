using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public string levelKey;

    public CameraFollowBox camera;

    public GameObject PlayerPrefab;
    private GameObject player;

    public int lives;
    private int tokens;
    public int tokensPerLife;

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

        MusicManager.Instance().LEVEL_MUSIC.Play();
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

    public string GetLevelKey()
    {
        return levelKey;
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

        if(tokens >= tokensPerLife)
        {
            AddLife();
            tokens -= tokensPerLife;
        }

        HUDManager.Instance().SetTokens(tokens);
    }

    public void SetWin()
    {
        PlayerPrefs.SetInt(levelKey, LockStatus.UNLOCKED);
        SceneManager.LoadScene("Overworld_Development");
    }

    public void SetLose()
    {
        SceneManager.LoadScene(levelKey);
    }
}
