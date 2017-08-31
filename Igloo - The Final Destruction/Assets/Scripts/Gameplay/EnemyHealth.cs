using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
{
    public override void HandleCollisions(Collision2D other)
    {
        string tag = other.transform.tag;

        if (tag.Equals("Player"))
        {
            TakeDamage(10);
        }
    }
}
