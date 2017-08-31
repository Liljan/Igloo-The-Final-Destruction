using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rigidbody2DSpawner : MonoBehaviour
{
    public GameObject rb2dObj;
    public int AMOUNT = 10;
    private GameObject[] particle;

    public bool destroyOnTime = true;
    public float DESTROY_TIME = 1.0f;
    private float destroyTime;

    public void Awake()
    {
        particle = new GameObject[AMOUNT];

        for (int i = 0; i < AMOUNT; i++)
        {
            particle[i] = Instantiate(rb2dObj, transform.position, Quaternion.identity);
        }

        destroyTime = 0.0f;

    }

    // Update is called once per frame
    void Update()
    {
        destroyTime += Time.deltaTime;

        if(destroyTime > DESTROY_TIME)
        {
            for (int i = 0; i < AMOUNT; i++)
            {
                Destroy(particle[i]);
            }

            Destroy(this);
        }
    }
}
