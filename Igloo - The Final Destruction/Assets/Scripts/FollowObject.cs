using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;

    // Update is called once per frame
    void Update()
    {
        if (!target)
            return;

        transform.position = target.position + offset;
    }
}
