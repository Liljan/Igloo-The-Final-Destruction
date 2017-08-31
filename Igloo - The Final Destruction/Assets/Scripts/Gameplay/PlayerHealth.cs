using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health
{

    public override void HandleCollisions(Collision2D other)
    {
        string tag = other.transform.tag;

        if (tag.Equals("Enemy"))
        {
            TakeDamage(1);
        }
    }
}
