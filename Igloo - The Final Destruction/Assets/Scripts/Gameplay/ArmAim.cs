using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmAim : MonoBehaviour
{
    public float sensitivity = 0.7f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float y = Input.GetAxis("Vertical");
        Debug.Log(y);

        if (y > sensitivity)
        {
            transform.localRotation = Quaternion.Euler(0.0f, 0.0f, 90.0f);
        }
        else if (y < -sensitivity)
        {
            transform.localRotation = Quaternion.Euler(0.0f, 0.0f, -90.0f);
        }
        else
        {
            transform.localRotation =  Quaternion.Euler(0.0f, 0.0f, 0.0f);
        }
    }
}
