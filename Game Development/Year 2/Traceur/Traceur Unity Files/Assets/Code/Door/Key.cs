using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public bool key = false;
    public bool open = false;
    public AudioSource pickup;
    public GameObject keyGUI;
    void Start()
    {
        keyGUI.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (key == true)
        {
            keyGUI.gameObject.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag ("Player"))
        {
            GameObject.Find("Key").transform.localScale = new Vector3(0, 0, 0);
            key = true;
            Open();
            pickup.Play();
        }
    }

    public void Open ()
    {
        open = true;
    }
}
