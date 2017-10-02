using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverworldPlayer : MonoBehaviour
{
    public float speed;
    public float gridDistance = 1F;

    public GameObject startNode;
    private Node currentNode = null;

    private Vector3 target;

    private AxisAsButton horizontal, vertical;

    public void Awake()
    {
        //horizontal = AxisAsButton.CreateAxisAsButton("Horizontal");
        //vertical = AxisAsButton.CreateAxisAsButton("Vertical");

        target = startNode.transform.position;
    }

    public void Update()
    {
        // If it has not reached a node
        if (transform.position != target)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        }
        // If transform has reached node
        else
        {
            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");

            // Horizontal Movement
            if (x < -0.1F && currentNode.LEFT)
                target += gridDistance * Vector3.left;
            else if (x > 0.1F && currentNode.RIGHT)
                target += gridDistance * Vector3.right;

            // Vertical movement
            if (y == 1F && currentNode.UP)
                target += gridDistance * Vector3.up;
            else if (y == -1F && currentNode.DOWN)
                target += gridDistance * Vector3.down;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("OverworldNode"))
            return;

        currentNode = collision.GetComponent<Node>();
    }

}
