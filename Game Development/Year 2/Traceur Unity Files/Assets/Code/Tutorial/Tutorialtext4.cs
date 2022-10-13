using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorialtext4 : MonoBehaviour
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
                gm.InputText.text = ("Now that you can swing, explore the area and find a key. You will need it to get out of the tutorial.");
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {

            gm.InputText.text = ("");

    }
}
