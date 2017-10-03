using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefabTest : MonoBehaviour
{
    private void Awake()
    {
        PlayerPrefs.SetInt("lvl_1_1", LockStatus.UNLOCKED);
        PlayerPrefs.SetInt("lvl_1_2", LockStatus.UNLOCKED);
    }
}
