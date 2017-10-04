using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverworldPlayer : MonoBehaviour
{
    public float speed;
    //public float gridDistance = 1F;

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
            if (x < -0.1F && currentNode.LEFT && !currentNode.lockLeft)
                target = currentNode.LEFT.transform.position;
            else if (x > 0.1F && currentNode.RIGHT && !currentNode.lockRight)
                target = currentNode.RIGHT.transform.position;

            // Vertical movement
            else if (y > 0.1F && currentNode.UP && !currentNode.lockUp)
                target = currentNode.UP.transform.position;
            else if (y < -0.1F && currentNode.DOWN && !currentNode.lockDown)
                target = currentNode.DOWN.transform.position;
        }
    }

    public void SetNode(Node n)
    {
        currentNode = n;
    }
}
