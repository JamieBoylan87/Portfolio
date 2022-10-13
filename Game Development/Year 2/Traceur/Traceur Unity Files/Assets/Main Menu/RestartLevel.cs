using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartLevel : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void Play1()
    {
        SceneManager.LoadScene("Level1");
    }

    public void Play2()
    {
        SceneManager.LoadScene("Level2");
    }

    public void Play3()
    {
        SceneManager.LoadScene("Level3");
    }

    public void Menu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }
}