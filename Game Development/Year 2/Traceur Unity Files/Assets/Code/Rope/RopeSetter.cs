using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeSetter : MonoBehaviour
{
    public Rope[] rope;
    private int index = 0;
    void Start()
    {
            
    }
    void Update()
    {
        //If you are hosting left mouse button and press Q, swing.
        if (Input.GetKeyDown(KeyCode.Q) && (Input.GetMouseButton(0)))
        {
            //Gets world position of mouse
            Vector2 worldPos = Camera.main .ScreenToWorldPoint(Input.mousePosition);
            rope[index].setStart(worldPos);
            
            index++;
            if (index > rope.Length - 1)
            {

                index = 0;
            }
            
        }

    }

    public void Death()
    {
        this.enabled = false;
    }
}
