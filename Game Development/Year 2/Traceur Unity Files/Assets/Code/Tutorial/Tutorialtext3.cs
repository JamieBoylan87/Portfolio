using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorialtext3 : MonoBehaviour
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
                gm.InputText.text = ("You can also use the rope to get to higher elevations. The further you are from the grapple point, the more force will be applied. Grapple to the platform ahead.");
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {

            gm.InputText.text = ("");

    }
}
