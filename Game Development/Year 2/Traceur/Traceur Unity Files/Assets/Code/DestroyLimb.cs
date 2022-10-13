using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyLimb : MonoBehaviour
{
    public GameObject LeftLeg;
    public GameObject LeftFoot;
    public GameObject RightLeg;
    public GameObject RightFoot;
    public GameObject RightArm;
    public GameObject RightHand;

    int lives = 3;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (lives == 3)
            {
                Destroy(this);

                Destroy(gameObject);
                Destroy(LeftLeg);
                Destroy(LeftFoot);
                lives = 2;
            }
            else if (lives == 2)
            {
                Destroy(this);
                Destroy(gameObject);
                Destroy(RightLeg,1);
                Destroy(RightFoot,1);
                lives = 1;
            }
            if (other.gameObject.tag == "Player")
            {
                if (lives == 3)
                {
                    Destroy(gameObject);
                    Destroy(this);
                    Destroy(LeftLeg,1);
                    Destroy(LeftFoot,1);
                    lives = 2;
                }
                else if (lives == 2)
                {
                    Destroy(gameObject);
                    Destroy(RightLeg);
                    Destroy(RightFoot);
                    lives = 1;
                }
                else if (lives == 1)
                {
                    Destroy(gameObject);
                    Destroy(this);
                    Destroy(RightArm);
                    lives = 0;
                }
            }
        }
    }
}
