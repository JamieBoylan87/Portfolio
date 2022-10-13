using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject key;
    public GameObject door;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Code to destroy key and door pulled from spongy
    void DestroyKey()
    {
        key = GameObject.FindGameObjectWithTag("Key");
        Destroy(key);
    }
    void OpenDoor()
    {
        door = GameObject.FindGameObjectWithTag("Door");
        Destroy(door);
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            DestroyKey();
            OpenDoor();
            Debug.Log("Hi");
        }
    }
}
