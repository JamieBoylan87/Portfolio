using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial
{
    public void GoToTutorial(string scene = "")
    {
        SceneManager.LoadScene(sceneName: "Tutorial");
    }
}