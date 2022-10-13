using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Enemy : MonoBehaviour
{
    public AIPath aiPath;
    public Rigidbody2D rb;
    public PlayerController playerController;

    void Update()
    {
        if (aiPath.desiredVelocity.x >= 0.0f)
        {
            transform.localScale = new Vector3(-10f, 10f, 10f);
        }
        else if (aiPath.desiredVelocity.x <= 0.01f)
        {
            transform.localScale = new Vector3(10f, 10f, 10f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Head" || collision.gameObject.name == "Hips")
        {
            Lives.health -= 1;
        }
        if (collision.gameObject.tag == "Player")
        {
            rb.velocity = new Vector2((Direction()) * -100, 1200 * Time.deltaTime);
        }
    }

    private int Direction()
    {
        if (aiPath.desiredVelocity.x >= 0.0f)
        {
            return -1;
        }
        else
        {
            return 1;
        }

    }
}
