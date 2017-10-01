using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeManager : MonoBehaviour
{
    public Node currentNode;

    private static NodeManager instance;

    private void Awake()
    {
        instance = this;
    }

    public static NodeManager Instance()
    {
        return instance;
    }
}
