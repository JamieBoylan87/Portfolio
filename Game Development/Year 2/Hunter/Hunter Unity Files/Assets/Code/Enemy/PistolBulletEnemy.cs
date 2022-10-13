using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolBulletEnemy : MonoBehaviour
{
    public ParticleSystem muzzleFlash;
    public ParticleSystem sparks;
    public GameObject barrell;
    private PlayerController pc;
    private bool hasCollided = false;

    void Start()
    {
        StartCoroutine(destroyAfterTime());
        Instantiate(muzzleFlash, gameObject.transform.position, Quaternion.identity);
        pc = GameObject.Find("Hips").GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (hasCollided == true)
        {
            Destroy(gameObject);
        }
    }



    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
            Instantiate(sparks, transform.position, Quaternion.identity);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && other.gameObject.name != "Shield")
        {
            hasCollided = true;
            pc.TakeDamage(4f);
        }
    }


    IEnumerator destroyAfterTime()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
