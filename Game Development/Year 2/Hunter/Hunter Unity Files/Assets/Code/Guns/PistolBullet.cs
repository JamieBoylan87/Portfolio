using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolBullet : MonoBehaviour
{
    public bool isDead = false;
    public ParticleSystem muzzleFlash;
    public ParticleSystem sparks;
    public ParticleSystem Blood;
    public PlayerController pc;
    private Rigidbody2D otherRb;
    public AudioSource hitG;
    public AudioSource hitE;


    void Start()
    {
        StartCoroutine(destroyAfterTime());
        Instantiate(muzzleFlash, GameObject.Find("Barrell").transform.position, Quaternion.identity);

        pc = GameObject.Find("Hips").GetComponent<PlayerController>();
    }

    private void Update()
    {
    }



    private void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);
        
        if (other.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
            Instantiate(sparks, transform.position, Quaternion.identity);
            hitG.Play();
        }
        if (other.gameObject.tag == "Enemy")
        {
            hitE.Play();
            Instantiate(Blood, transform.position, Quaternion.identity);
            otherRb = GameObject.Find(other.gameObject.name).GetComponent<Rigidbody2D>();
            otherRb.velocity = new Vector2(10, 10);
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



        }
    }


    IEnumerator destroyAfterTime()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }

}
