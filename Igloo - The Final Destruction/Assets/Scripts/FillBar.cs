using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillBar : MonoBehaviour
{
    public Transform fillBar;

    public void SetEnabled(bool b)
    {
        this.gameObject.SetActive(b);
    }

    public void SetValue(float v)
    {
        Vector3 scale = fillBar.localScale;
        fillBar.localScale = new Vector3(v, scale.y, scale.z);
    }
}
