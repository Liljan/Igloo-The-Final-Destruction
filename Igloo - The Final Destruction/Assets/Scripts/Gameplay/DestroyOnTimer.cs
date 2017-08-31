using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTimer : MonoBehaviour
{
    public float TIME;
    private float currentTime;

    public void Awake()
    {
        currentTime = 0.0f;
    }

    public void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime > TIME)
            Destroy(this.gameObject);
    }
}
