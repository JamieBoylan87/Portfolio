using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public static void nextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public static void replayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public static void Controls()
    {
        SceneManager.LoadScene("Control");
    }
    public static void Settings()
    {
        SceneManager.LoadScene("Settings");
    }
    public static void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public static void Quit()
    {
        Application.Quit();
    }
}
