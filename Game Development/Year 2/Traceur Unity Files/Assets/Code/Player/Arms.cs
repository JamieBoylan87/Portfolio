using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arms : MonoBehaviour
{
    //1 or 0, checks which arm you are using
    public int side;
    //Speed of arms extension
    public float speed = 300f;
    public Camera cam;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //Gets Mouse position
        Vector3 mousePos = new Vector3(cam.ScreenToWorldPoint(Input.mousePosition).x, cam.ScreenToWorldPoint(Input.mousePosition).y, 0f);
        Vector3 difference = mousePos - transform.position;

        //Rotation of arm 
        float rotationZ = Mathf.Atan2(difference.x, -difference.y) * Mathf.Rad2Deg;

        //Checks which mouse button is being pressed (0 is left, 2 is right)
        if (Input.GetMouseButton(side))
        {
            //Moves arm in direction of mouse
            rb.MoveRotation(Mathf.LerpAngle(rb.rotation, rotationZ, speed * Time.deltaTime));
        }
    }

    public void Death()
    {
        this.enabled = false;
    }
}
 