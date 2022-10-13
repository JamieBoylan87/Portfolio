using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorialtext6 : MonoBehaviour
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
                gm.InputText.text = ("You finished the tutorial! Heres a few tips:  (1) You can cancel your rope to keep your momentum by throwing another rope in a random direction. (2) Lava wont be the only danger, you will be chased by a ghost. Dont let him touch you!");
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {

            gm.InputText.text = ("");

    }
}
