 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float movementForce;
    public float jumpForce;
    [Space(5)]
    [Range(0, 100f)] public float raycastDistance = 1.5f;
    private Rigidbody2D rb;
    public LayerMask whatIsGround;
    public float xDir;
    public Animator anim;
    public Transform head;
    private GameObject parent;
    private float maxHealth = 100f;
    public float currentHealth;
    private HealthBar healthBar;
    private SlowMotion slowM;
    public float slowTimer = 100;
    public EnemiesLeft el;
    public GameObject canvas;
    public GameObject deathScreen;
    public AudioSource foot;
    private AudioSource gun;
    private AudioSource music;
    private AudioSource rope;



    private void Start()
    {
        music = GameObject.Find("Music").GetComponent<AudioSource>();
        gun = GameObject.Find("GunAUDIO").GetComponent<AudioSource>();
        rope = GameObject.Find("RopeAUDIO").GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        healthBar = GameObject.Find("HealthBar").GetComponent<HealthBar>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        slowM = GameObject.Find("SlowBar").GetComponent<SlowMotion>();
        StartCoroutine(SlowMotionIncrease());


    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (slowTimer > 0  && Input.GetKey(KeyCode.LeftShift))
        {
            Time.timeScale = 0.25f;
            Time.fixedDeltaTime = 0.02f * Time.timeScale;
            rope.pitch = 0.5f;
            foot.pitch = 0.5f;
            music.pitch = 0.5f;
            gun.pitch = 0.5f;
            StartCoroutine(SlowMotion());
        }
        if(slowTimer < 0 || Input.GetKeyUp(KeyCode.LeftShift))
        {
            Time.timeScale = 1f;
            Time.fixedDeltaTime = 0.02f * Time.timeScale;
            rope.pitch = 1f;
            foot.pitch = 1f;
            music.pitch = 1f;
            gun.pitch = 1f;
        }
        if(slowTimer <= 0)
        {
            slowTimer = 0;
        }
        if (slowTimer >= 100)
        {
            slowTimer = 100;
        }
        if (currentHealth <= 0)
        {
            DestroyPlayer();
        }
        slowM.SetSlowMo(slowTimer);
        StartCoroutine(PlayerDestroy());
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }
    private void FixedUpdate()
    {
        Movement();
        Jump();
    }

    private void Movement()
    {
        if (IsGrounded())
        {

            xDir = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector2(xDir * (movementForce * Time.deltaTime), rb.velocity.y);
            if (xDir != 0)
            {
                head.localScale = new Vector2(xDir, 1f);
            }
            if (xDir > 0)
            {
                anim.SetBool("Walk", true);
                anim.SetBool("WalkLeft", false);
            }
            if (xDir < 0)
            {
                anim.SetBool("Walk", false);
                anim.SetBool("WalkLeft", true);
            }
            if (xDir == 0)
            {
                anim.SetBool("Walk", false);
                anim.SetBool("WalkLeft", false);
            }

            if (xDir < 0 || xDir > 0)
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
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W))
        {
            if (IsGrounded())
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce * Time.deltaTime);
            }
        }
    }

    private bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, raycastDistance, whatIsGround);
        return hit.collider != null;
    }
    private void EnemyExplode(GameObject enemy)
    {
        HingeJoint2D[] allChildren = (enemy.transform.root).GetComponentsInChildren<HingeJoint2D>();
        foreach (HingeJoint2D child in allChildren)
        {
            Destroy(child);
        }
    }

    private void DestroyPlayer()
    {
        Balance[] allChildren1 = (gameObject.transform.root).GetComponentsInChildren<Balance>();
        foreach (Balance child in allChildren1)
        {
            Destroy(child);
        }
        HingeJoint2D[] allChildren2 = (gameObject.transform.root).GetComponentsInChildren<HingeJoint2D>();
        foreach (HingeJoint2D child in allChildren2)
        {
            Destroy(child);
        }
        movementForce = 0f;
        jumpForce = 0f;
        Arm[] allChildren3 = (gameObject.transform.root).GetComponentsInChildren<Arm>();
        foreach (Arm child in allChildren3)
        {
            Destroy(child);
        }
        Arm1[] allChildren4 = (gameObject.transform.root).GetComponentsInChildren<Arm1>();
        foreach (Arm1 child in allChildren4)
        {
            Destroy(child);
        }
        Destroy(GameObject.Find("Pistol"));
        Time.timeScale = 0.25f;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;

        StartCoroutine(PlayerDestroy());
        canvas.SetActive(false);
        deathScreen.SetActive(true);
    }

    private void EnemyDestroyTimer(GameObject enemy)
    {
        parent = (enemy.transform.root).gameObject;
        parent.SetActive(false);
        

    }

    public void EnemyTimer(GameObject enemy)
    {
        StartCoroutine(EnemyDestroy(enemy));
        StartCoroutine(Explode(enemy));
    }

    IEnumerator Explode(GameObject enemy)
    {
        yield return new WaitForSeconds(1);
        EnemyExplode(enemy);
    }

    IEnumerator EnemyDestroy(GameObject enemy)
    {
        yield return new WaitForSeconds(5);
        EnemyDestroyTimer(enemy);

    }

    IEnumerator SlowMotion()
    {
        yield return new WaitForSeconds(.01f);
        slowTimer -= 0.1f;
    }

    IEnumerator SlowMotionIncrease()
    {
        yield return new WaitForSeconds(2);
        slowTimer += 10;
        StartCoroutine(SlowMotionIncrease());
    }
    IEnumerator PlayerDestroy()
    {
        yield return new WaitForSeconds(3);
    }
}
