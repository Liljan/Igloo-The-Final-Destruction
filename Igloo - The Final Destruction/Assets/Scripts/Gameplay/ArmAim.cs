﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmAim : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.localRotation = Quaternion.Euler(0.0f, 0.0f, Mathf.Asin(y) * Mathf.Rad2Deg);
    }
}
