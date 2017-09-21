using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBorder : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerHealth ii = collision.gameObject.GetComponent<PlayerHealth>();
            ii.TakeDamage(1000000);
        }
    }
}
