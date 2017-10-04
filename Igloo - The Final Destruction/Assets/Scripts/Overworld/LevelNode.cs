using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelNode : MonoBehaviour
{
    public string levelKey;

    public GameObject HUD;
    public Transform levelExit;

    private bool hasFocus = false;

    private void Awake()
    {
        HUD.SetActive(false);
    }

    private void Update()
    {
        if (!hasFocus)
            return;

        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("Load level 1");
            GameData.USE_DEFAULT_START_POS = false;
            GameData.START_POSITION = levelExit.position;

            SceneManager.LoadScene(levelKey);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("OverworldPlayer"))
            return;

        HUD.SetActive(true);
        hasFocus = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("OverworldPlayer"))
            return;

        HUD.SetActive(false);
        hasFocus = false;
    }
}
