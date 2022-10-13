using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{ 
 public ScoreManager ScoreText;

private int timer;
    void Update()
    {

        timer += (int)Time.deltaTime;

        if (timer > 5f)
        {


            //We only need to update the text if the score changed.
            ScoreText.AddPoint();

            //Reset the timer to 0.
            timer = 0;
        }
    }
}
