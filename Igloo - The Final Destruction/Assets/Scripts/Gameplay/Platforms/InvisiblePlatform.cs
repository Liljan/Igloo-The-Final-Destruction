using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisiblePlatform : MonoBehaviour {

    private SpriteRenderer renderer;
    private bool isTriggered = false;

    public void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();
        renderer.enabled = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isTriggered)
            return;

        string tag = collision.gameObject.tag;

        if (tag == "Player")
        {
            renderer.enabled = true;
            isTriggered = true;
        }
    }
}
