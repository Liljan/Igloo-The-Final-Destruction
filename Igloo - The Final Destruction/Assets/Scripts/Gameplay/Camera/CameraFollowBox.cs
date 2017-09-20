using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowBox : MonoBehaviour
{
    public Vector2 margin;
    public Vector2 smoothness;
    //public Vector2 maxXY;        // The maximum x and y coordinates the camera can have.
    //public Vector2 minXY;        // The minimum x and y coordinates the camera can have.
    public Vector2 offset;

    // public Vector2 offset;

    private Transform player;        // Reference to the player's transform.

    private void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!player)
            return;

        Vector2 target = new Vector2(transform.position.x, transform.position.y);

        if (IsOutsideOfXMargin())
            target.x = Mathf.Lerp(transform.position.x, player.position.x, smoothness.x * Time.deltaTime);

        if (isOutsideOfYMargin())
            target.y = Mathf.Lerp(transform.position.y, player.position.y, smoothness.y * Time.deltaTime);

        transform.position = new Vector3(target.x, target.y, transform.position.z);
    }

    public void SetTarget(Transform t)
    {
        player = t;
    }

    private bool IsOutsideOfXMargin()
    {
        // Returns true if the distance between the camera and the player in the x axis is greater than the x margin.
        return Mathf.Abs(transform.position.x - player.position.x) > margin.x;
    }

    private bool isOutsideOfYMargin()
    {
        // Returns true if the distance between the camera and the player in the y axis is greater than the y margin.
        return Mathf.Abs(transform.position.y - player.position.y + offset.y) > margin.y;
    }

    private void OnDrawGizmos()
    {
        if (!player)
            return;

        Gizmos.color = Color.red;
        Vector3 pos = transform.position + new Vector3(offset.x, offset.y, 0F);

        Gizmos.DrawWireCube(pos, new Vector3(2F * margin.x, 2F * margin.y, 1F));
    }
}
