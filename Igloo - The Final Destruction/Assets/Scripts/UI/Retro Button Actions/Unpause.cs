using UnityEngine;

public class Unpause : SelectAction
{
    public override void Select()
    {
        PauseManager.Instance().SetPaused(false);
    }
}