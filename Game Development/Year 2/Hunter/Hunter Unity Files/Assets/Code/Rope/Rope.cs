using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{
    //Origin (arm)
    public Rigidbody2D origin;


    //Material of rope
    public Material mat;
    //Renders Line
    private LineRenderer line;

    private bool pull = false;
    private bool update = false;

    //How long the rope will stay connected
    public float stayTime = 1f;
    //Width of rope
    public float lineWidth = .1f;
    //Speed the rope is projected at
    public float speed = 75f;
    //How much force is applied in direction of rope
    public float pullForce = 10f;
    private Vector3 velocity;
    private IEnumerator timer;

    void Start()
    {
        line = GetComponent<LineRenderer>();
        if (!line)
        {
            line = gameObject.AddComponent<LineRenderer>();
        }
        line.startWidth = lineWidth;
        line.endWidth = lineWidth;
        line.material = mat;

    }

    public void setStart(Vector2 targetPos)
    {
        //Creates a vector in direction of mouse
        Vector2 dir = targetPos - origin.position;
        dir = dir.normalized;
        velocity = dir * speed;  
        transform.position = origin.position + dir;
        pull = false;
        update = true;
        //Timer to remove rope
        if (timer != null)
        {
            StopCoroutine(timer);
            timer = null;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (!update)
        {
            return;
        }

        //Apply force to rope if you hit a certain object (Red blocks)
        if (pull)
        {
            Vector2 dir = (Vector2)transform.position -origin.position;
            origin.AddForce(dir * pullForce);
        }
        else
        //Destroy the rope
        {
            transform.position += velocity * Time.deltaTime;
            float distance = Vector2.Distance(transform.position, origin.position);
            if (distance > 50)
            {
                update = false;
                line.SetPosition(0, Vector2.zero);
                line.SetPosition(1, Vector2.zero);
                return;

            }
        }
        line.SetPosition(0, transform.position);
        line.SetPosition(1, origin.position);

    }

    //Destroy rope after certain time
    IEnumerator reset (float delay)
    {
        yield return new WaitForSeconds(delay);
        update = false;
        line.SetPosition(0, Vector2.zero);
        line.SetPosition(1, Vector2.zero);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ground")
        {
            velocity = Vector2.zero;
            pull = true;
            timer = reset(stayTime);
            StartCoroutine(timer);

        }
        else
        {
            velocity = Vector2.zero;
            timer = reset(0);
            StartCoroutine(timer);
        }
    }

}
