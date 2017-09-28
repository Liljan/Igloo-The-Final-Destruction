using System;
using UnityEngine;

public class Unpause : SelectAction
{
    public PauseManager pauseManager;

    public override void Select()
    {
        pauseManager.SetPaused(false);
    }
}
