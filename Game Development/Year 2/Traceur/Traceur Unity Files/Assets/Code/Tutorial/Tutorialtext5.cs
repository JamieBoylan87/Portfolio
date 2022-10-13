using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorialtext5 : MonoBehaviour
{
    private GameMaster gm;

    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
                gm.InputText.text = ("Good Job! You found the key. Find the door to finish the level.");
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {

            gm.InputText.text = ("");

    }
}
