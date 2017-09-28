using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GotoScene : SelectAction
{
    public string scene;

    public override void Select()
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(scene));
    }
}
