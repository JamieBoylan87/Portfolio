using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public GameObject EndScreen;
    private void Start()
    {

    }
    public void ToNextLevel()
    {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        Time.timeScale = 1;
        EndScreen.gameObject.SetActive(false);
    }
}
