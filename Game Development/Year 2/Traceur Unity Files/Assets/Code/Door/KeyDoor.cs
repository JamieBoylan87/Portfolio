using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class KeyDoor : MonoBehaviour
{
    public int LevelToLoad;
    public GameObject Key;
    private Key key;
    public bool keyCheck = false;
    private GameMaster gm;
    public GameObject EndScreen;
    public Text scoreText;
    private ScoreManager sm;
    private ScoreManager1 sm1;
    private ScoreManager2 sm2;

    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
        sm = GameObject.FindGameObjectWithTag("GameController").GetComponent<ScoreManager>();
        sm1 = GameObject.FindGameObjectWithTag("GameController").GetComponent<ScoreManager1>();
        sm2 = GameObject.FindGameObjectWithTag("GameController").GetComponent<ScoreManager2>();


        key = Key.GetComponent<Key>();
        EndScreen.gameObject.SetActive(false);

    }

    private void Update()
    {
       keyCheck = key.key ;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (key.open)
            {
                gm.InputText.text = ("[E] to Enter");
                if (Input.GetKey("e"))
                {
                    Time.timeScale = 0f;
                    EndScreen.gameObject.SetActive(true);
                    if ("Level1" == SceneManager.GetActiveScene().name)
                    {
                        sm.checkHighscore();
                        scoreText.text = sm.score.ToString();

                    }
                    else if ("Level2" == SceneManager.GetActiveScene().name)
                    {
                        sm1.checkHighscore();
                        scoreText.text = sm1.score.ToString();

                    }
                    else if ("Level3" == SceneManager.GetActiveScene().name)
                    {
                        sm2.checkHighscore();
                        scoreText.text = sm2.score.ToString();

                    }
                }
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (key.open)
            {
                if (Input.GetKey("e"))
                {
                    Time.timeScale = 0f;
                    EndScreen.gameObject.SetActive(true);
                    if ("Level1" == SceneManager.GetActiveScene().name)
                    {
                        sm.checkHighscore();
                        scoreText.text = sm.score.ToString();
                    }
                    else if ("Level2" == SceneManager.GetActiveScene().name)
                    {
                        sm1.checkHighscore();
                        scoreText.text = sm1.score.ToString();

                    }
                    else if ("Level3" == SceneManager.GetActiveScene().name)
                    {
                        sm2.checkHighscore();
                        scoreText.text = sm2.score.ToString();

                    }
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (key.open)
        {
            gm.InputText.text = ("");
        }
    }
}
