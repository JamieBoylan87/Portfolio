using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AssaultRifle : MonoBehaviour
{
    private Rigidbody2D rb;
    private Rigidbody2D arm;
    private Transform hand;
    private Transform barrell;
    private Transform weapon;
    public int speed = 10;
    private bool inHand = true;
    private bool canPickup = false;
    public Rigidbody2D gameObj;
    private bool canShoot = true;
    public float fireDelay = 0.3f;
    private Rigidbody2D otherRb;
    private GameObject eGun;
    public ParticleSystem Blood;
    private bool inAir = false;
    private bool canThrow = true;
    private GameObject throwUI;
    private bool canReturn = true;
    private GameObject ReturnUI;
    public int ARbullets = 20;
    public Text ammo;
    private PlayerController pc;
    public bool canSwitch = true;
    public WeaponSwitch ws;
    public AudioSource gun;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pc = GameObject.Find("Hips").GetComponent<PlayerController>();
        throwUI = GameObject.Find("ThrowAbilityUI");
        ReturnUI = GameObject.Find("ReturnAbilityUI");
        arm = GameObject.Find("RightHand").GetComponent<Rigidbody2D>();
        hand = GameObject.Find("Weapon").GetComponent<Transform>();
        barrell = GameObject.Find("Barrell").GetComponent<Transform>();
        weapon = GameObject.Find("RightArm").GetComponent<Transform>();
        arm = GameObject.Find("RightHandEnemy").GetComponent<Rigidbody2D>();
        weapon = GameObject.Find("RightArmEnemy").GetComponent<Transform>();
        eGun = GameObject.Find("EnemyPistol");
        ARbullets = 20;
        ws = GameObject.Find("Controller").GetComponent<WeaponSwitch>();
    }

    // Update is called once per frame
    void Update()
    {
        ammo.text = ARbullets.ToString();
        Vector3 mousePos = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0f);
        Vector3 difference = mousePos - transform.position;

        if (canSwitch == true && Input.GetKeyUp(KeyCode.Tab))
        {
            ws.change();
        }

        if (canShoot && canThrow && Input.GetMouseButton(1) && Input.GetKeyDown(KeyCode.Q))
        {
            throwUI.SetActive(false);
            transform.SetParent(null);
            gameObject.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            rb.velocity = 2 * difference;
            inHand = false;
            gameObject.layer = LayerMask.NameToLayer("Default");
            inAir = true;
            canThrow = false;
            StartCoroutine(ThrowDelay());
        }

        if (ARbullets >= 1 && Input.GetMouseButton(1) && Input.GetMouseButton(0) && canShoot == true)
        {
            Vector3 shootDirection;
            gun.Play();
            shootDirection = Input.mousePosition;
            shootDirection.z = 0.0f;
            shootDirection = Camera.main.ScreenToWorldPoint(shootDirection);
            shootDirection = shootDirection - transform.position;
            shootDirection.y += Random.Range(-3, 3);
            Rigidbody2D bulletInstance = Instantiate(gameObj, barrell.position, Quaternion.Euler(new Vector3(0, 0, (weapon.eulerAngles.z)-90))) as Rigidbody2D;
            bulletInstance.velocity = new Vector2(shootDirection.x * speed, shootDirection.y * speed);
            arm.velocity = new Vector2(0,10);
            canShoot = false;
            canSwitch = false;
            ARbullets--;
            StartCoroutine(FireDelay());

        }
        if (inHand == false && canReturn && Input.GetMouseButton(1) && Input.GetKey(KeyCode.F))
        {
            ReturnUI.SetActive(false);
            Vector3 armDirection;
            armDirection = hand.transform.position;
            armDirection.z = 0;
            armDirection = armDirection - transform.position;
            rb.velocity = new Vector2(armDirection.x*speed/2, armDirection.y*speed / 2);
            canPickup = true;
            canReturn = false;
            StartCoroutine(ReturnDelay());
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if ((inHand == false) && (canPickup == true))
            {
                transform.SetParent(hand, false);
                gameObject.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
                inHand = true;
                gameObject.layer = LayerMask.NameToLayer("Player");
                transform.localScale = new Vector3(1f, 1f, 1f);
                transform.localPosition = new Vector3(0, 0, 0f);
                transform.localRotation = Quaternion.Euler(0, 0, 0);
                Debug.Log("Hello");
                canPickup = false;
            }
        }
        if (other.gameObject.tag == "Ground")
        {
            canPickup = true;
            inAir = false;
        }

       
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (inAir == true)
        {

            if (other.gameObject.tag == "Enemy")
            {
                otherRb = GameObject.Find(other.gameObject.name).GetComponent<Rigidbody2D>();
                otherRb.velocity = new Vector2(50, 50);
                pc.EnemyTimer(other.gameObject);
                Debug.Log("Hi");

                Balance[] allChildren = (other.transform.root).GetComponentsInChildren<Balance>();
                foreach (Balance child in allChildren)
                {
                    Destroy(child);
                }

                EnemyShooting[] allChildren2 = (other.transform.root).GetComponentsInChildren<EnemyShooting>();
                foreach (EnemyShooting child in allChildren2)
                {
                    Destroy(child);
                }

                EnemyGun[] allChildren3 = (other.transform.root).GetComponentsInChildren<EnemyGun>();
                foreach (EnemyGun child in allChildren3)
                {
                    Destroy(child);
                }

                Rigidbody2D[] allChildren5 = (other.transform.root).GetComponentsInChildren<Rigidbody2D>();
                foreach (Rigidbody2D child in allChildren5)
                {
                    child.bodyType = RigidbodyType2D.Dynamic;
                }
                canPickup = true;
                otherRb = GameObject.Find(other.gameObject.name).GetComponent<Rigidbody2D>();
                eGun.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

            }
        }
    }

    IEnumerator FireDelay()
    {
        yield return new WaitForSeconds(fireDelay);
        canShoot = true;
        canSwitch = true;

    }

    IEnumerator ThrowDelay()
    {
        yield return new WaitForSeconds(5);
        canThrow = true;
        throwUI.SetActive(true);
    }

    IEnumerator ReturnDelay()
    {
        yield return new WaitForSeconds(10);
        canReturn = true;
        ReturnUI.SetActive(true);
    }
}
