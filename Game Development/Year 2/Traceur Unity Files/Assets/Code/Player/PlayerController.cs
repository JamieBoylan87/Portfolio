 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Movement particles
    public ParticleSystem dust1;
    public ParticleSystem dust;
    public AudioSource foot;

    //Movement speed
    public float movementForce;
    //Jump height
    public float jumpForce;
    [Space(5)]
    //Distance to check for platform beneath player (Higher number means you can basically fly)
    [Range(0, 100f)] public float raycastDistance = 1.5f;
    private Rigidbody2D rb;
    public float xDir;
    public LayerMask whatIsGround;

    public Animator anim;
    public Transform head;
    public GameObject keyGUI;

    //Door Opening
    public GameObject[] gameObjects;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        keyGUI.gameObject.SetActive(false);
    }

    private void FixedUpdate()
    {
        Movement();
        Jump();
    }


    private void Movement()
    {
        //If you are on the ground, move
        if (IsGrounded())
        {

            xDir = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector2(xDir * (movementForce * Time.deltaTime), rb.velocity.y);
            //Animation code
            if (xDir != 0)
            {
                head.localScale = new Vector3(xDir, 1f, 1f);
                CreateDust();
            }
            if (xDir > 0)
            {
                anim.SetBool("Walk", true);
                anim.SetBool("WalkLeft", false);
                CreateDust();
                

            }
            if (xDir < 0)
            {
                anim.SetBool("Walk", false);
                anim.SetBool("WalkLeft", true);
                CreateDust();


            }
            if (xDir == 0)
            {
                anim.SetBool("Walk", false);
                anim.SetBool("WalkLeft", false);
            }

            if (xDir <0 || xDir >0)
            {
                if (!foot.isPlaying)
                {
                    foot.Play();
                }
                
            }
            else
            {

                    foot.Stop();
            }
        }
        else
        {
            foot.Stop();

        }
    }

    private void Jump()
    {
        //Jump
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W))
        {
            if (IsGrounded())
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce * Time.deltaTime);
                CreateDust();
            }
        }
    }

    public bool IsGrounded()
    {
        //If you are grounded return true
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, raycastDistance, whatIsGround);
        return hit.collider != null;
    }

    public void Death()
    {
        this.enabled = false;
    }

    void CreateDust()
    {
        dust.Play();
        dust1.Play();
        

    }

}
