using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorialtext1 : MonoBehaviour
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
                gm.InputText.text = ("Welcome to Traceur. Use WASD to move around and jump. Hold left or right mouse button down while moving your mouse to control your arms.");
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {

            gm.InputText.text = ("");

    }
}
