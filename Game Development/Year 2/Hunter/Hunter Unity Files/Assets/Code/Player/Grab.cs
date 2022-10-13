using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{
    public Rigidbody2D hand;
    public int side;

    private GameObject currentlyHolding;
    private bool canGrab;
    private FixedJoint2D joint;

    private void Update()
    {
        if (Input.GetMouseButtonDown(side))
        {
            canGrab = true;
        }

        if (Input.GetMouseButtonUp(side))
        {
            canGrab = false;
        }

        if (!canGrab && currentlyHolding != null)
        {
            FixedJoint2D[] joints = currentlyHolding.GetComponents<FixedJoint2D>();
            for (int i = 0; i < joints.Length; i++)
            {
                if (joints[i].connectedBody == hand)
                {
                    Destroy(joints[i]);
                }
            }
            joint = null;
            currentlyHolding = null;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (canGrab && other.gameObject.GetComponent<Rigidbody2D>() != null)
        {
            currentlyHolding = other.gameObject;
            joint = currentlyHolding.AddComponent<FixedJoint2D>();
            joint.connectedBody = hand;
        }
    }
}
