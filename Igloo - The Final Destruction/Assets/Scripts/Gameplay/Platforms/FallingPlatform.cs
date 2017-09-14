using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    private Rigidbody2D rb2d;

    public float time;
    private bool isFalling = false;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        string tag = collision.gameObject.tag;

        if (tag == "Player")
        {
            StartCoroutine(Fall());
        }
    }

    private IEnumerator Fall()
    {
        yield return new WaitForSeconds(time);
        rb2d.isKinematic = false;
        GetComponent<Collider2D>().isTrigger = true;
        isFalling = true;
    }

    private void OnBecameInvisible()
    {
        Debug.Log("Not visible");
        if (isFalling)
            Destroy(this.gameObject);
    }
}
