using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorialtext2 : MonoBehaviour
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
                gm.InputText.text = ("While holding down left mouse button, press q to shoot a rope towards your mouse. The rope will only attach to certain objects which are usually green and glowing. Dont touch the lava and swing to the other side.");
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {

            gm.InputText.text = ("");

    }
}
