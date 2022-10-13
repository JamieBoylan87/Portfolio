using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    private float speed = 300f;
    private Transform player;
    private Rigidbody2D rb;



    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("PlayerPosition").GetComponent<Transform>();
    }

    private void Update()
    {
        Vector3 playerPos = new Vector3(player.transform.position.x, player.transform.position.y, 0f);
        Vector3 difference = playerPos - transform.position;
        float rotationZ = Mathf.Atan2(difference.x, -difference.y) * Mathf.Rad2Deg;
        rb.MoveRotation(Mathf.LerpAngle(rb.rotation, rotationZ, speed * Time.deltaTime));
    }

}
