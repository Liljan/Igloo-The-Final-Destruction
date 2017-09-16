using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public GameObject platform;

    public Transform[] points;
    private Transform currentPoint;

    private int currentPointIndex = 0;
    public float speed = 1.0f;

    public void Awake()
    {
        currentPoint = points[currentPointIndex];
    }

    // Update is called once per frame
    void Update()
    {
        platform.transform.position = Vector3.MoveTowards(platform.transform.position, currentPoint.position, Time.deltaTime * speed);

        if (platform.transform.position == currentPoint.position)
        {
            ++currentPointIndex;
            if (currentPointIndex == points.Length)
            {
                currentPointIndex = 0;

            }

            currentPoint = points[currentPointIndex];
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        string tag = collision.gameObject.tag;

        if (tag == "Player" || tag == "Enemy")
        {
            collision.gameObject.transform.parent = transform;
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        string tag = collision.gameObject.tag;

        if (tag == "Player" || tag == "Enemy")
        {
            collision.gameObject.transform.parent = null;
        }
    }
}
