using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject spawnObject;
    private bool hasSpawned = false;

    private void OnBecameVisible()
    {
        if (hasSpawned)
            return;

        Instantiate(spawnObject, transform.position, Quaternion.identity);
        hasSpawned = true;
    }

    private void OnBecameInvisible()
    {
        Debug.Log("Invisible");
    }
}
