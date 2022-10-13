using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    public Rigidbody2D gameObj;
    private Transform barrell;
    public float fireDelay = 2f;
    private Rigidbody2D arm;
    private Transform player;
    private Transform weapon;
    public bool canShoot = true;
    private float speed = 2;
    public bool IsEnabled = true;
    public PistolBullet pb;
    public GameObject prefab;
    private AudioSource gun;




    void Start()
    {
        gun = GameObject.Find("GunAUDIO").GetComponent<AudioSource>();
        Transform[] allChildren2 = (gameObject.transform.root).GetComponentsInChildren<Transform>();
        foreach (Transform child in allChildren2)
        {
            if (child.gameObject.name == "RightHandEnemy" || child.gameObject.name == "RightHandEnemy1" || child.gameObject.name == "RightHandEnemy2" || child.gameObject.name == "RightHandEnemy3" || child.gameObject.name == "RightHandEnemy4" || child.gameObject.name == "RightHandEnemy5" || child.gameObject.name == "RightHandEnemy6" || child.gameObject.name == "RightHandEnemy7" || child.gameObject.name == "RightHandEnemy8" || child.gameObject.name == "RightHandEnemy9" || child.gameObject.name == "RightHandEnemy10" || child.gameObject.name == "RightHandEnemy11" || child.gameObject.name == "RightHandEnemy12" || child.gameObject.name == "RightHandEnemy13" || child.gameObject.name == "RightHandEnemy14" || child.gameObject.name == "RightHandEnemy15" || child.gameObject.name == "RightHandEnemy16")
            { 
                arm = child.GetComponent<Rigidbody2D>();
            }
        }
        Transform[] allChildren = (gameObject.transform.root).GetComponentsInChildren<Transform>();
        foreach (Transform child in allChildren)
        {
            if (child.name == "EnemyBarrell" || child.name == "EnemyBarrell1" || child.name == "EnemyBarrell2" || child.name == "EnemyBarrell3" || child.name == "EnemyBarrell4" || child.name == "EnemyBarrell5" || child.name == "EnemyBarrell6" || child.name == "EnemyBarrell7" || child.name == "EnemyBarrell8" || child.name == "EnemyBarrell9" || child.name == "EnemyBarrell10" || child.name == "EnemyBarrell11" || child.name == "EnemyBarrell12" || child.name == "EnemyBarrell13" || child.name == "EnemyBarrell14" || child.name == "EnemyBarrell15" || child.name == "EnemyBarrell16")
            {
               barrell = child.GetComponent<Transform>();
            }
        }
        player = GameObject.Find("PlayerPosition").GetComponent<Transform>();

        Transform[] allChildren3 = (gameObject.transform.root).GetComponentsInChildren<Transform>();
        foreach (Transform child in allChildren)
        {
            if (child.name == "WeaponEnemy" || child.name == "WeaponEnemy1" || child.name == "WeaponEnemy2" || child.name == "WeaponEnemy3" || child.name == "WeaponEnemy4" || child.name == "WeaponEnemy5" || child.name == "WeaponEnemy6" || child.name == "WeaponEnemy7" || child.name == "WeaponEnemy8" || child.name == "WeaponEnemy9" || child.name == "WeaponEnemy10" || child.name == "WeaponEnemy11" || child.name == "WeaponEnemy12" || child.name == "WeaponEnemy13" || child.name == "WeaponEnemy14" || child.name == "WeaponEnemy15" || child.name == "WeaponEnemy16")
            {
                weapon = child.GetComponent<Transform>();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = new Vector3((player.transform.position).x, (player.transform.position).y, 0);
        float dist = Vector3.Distance(player.position, transform.position);
        

        if (Mathf.Abs(dist) < 10 && canShoot == true)
        {
            gun.Play();
            Vector3 shootDirection;
            shootDirection = new Vector3(playerPos.x, playerPos.y, 0);
            shootDirection.z = 0.0f;
            shootDirection = shootDirection - transform.position;
            Rigidbody2D bulletInstance = Instantiate(gameObj, barrell.position, Quaternion.Euler(new Vector3(0, 0, (weapon.eulerAngles.z) - 90))) as Rigidbody2D;
            bulletInstance.velocity = new Vector2(shootDirection.x * speed, shootDirection.y * speed);
            arm.velocity = new Vector2(0, 10);
            canShoot = false;
            Debug.Log("HI");
            StartCoroutine(FireDelay());
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
    }

    IEnumerator FireDelay()
    {
        yield return new WaitForSeconds(fireDelay);
        canShoot = true;
    }

}
