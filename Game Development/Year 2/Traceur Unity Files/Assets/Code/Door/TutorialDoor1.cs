using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialDoor1 : MonoBehaviour
{
    public int LevelToLoad;
    public GameObject Key;
    private Key key;
    public bool keyCheck = false;
    private GameMaster gm;

    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
        key = Key.GetComponent<Key>();
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
                    SceneManager.LoadScene("Main Menu");
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
                    SceneManager.LoadScene("Main Menu");

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
