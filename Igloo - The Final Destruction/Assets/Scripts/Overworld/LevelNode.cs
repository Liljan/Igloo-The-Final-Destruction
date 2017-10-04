using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelNode : MonoBehaviour
{
    public string levelKey;

    public GameObject HUD;

    private void Awake()
    {
        HUD.SetActive(false);
    }

    private void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            Debug.Log("Load level 1");
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("OverworldPlayer"))
            return;

        HUD.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("OverworldPlayer"))
            return;

        HUD.SetActive(false);
    }

}
