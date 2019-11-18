using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonSceneManager : MonoBehaviour {

  public void NextScene()
    {
        SceneController.sceneControl.NextScene();
    }
    public void PreviousScene()
    {
        SceneController.sceneControl.PreviousScene();
    }
}
