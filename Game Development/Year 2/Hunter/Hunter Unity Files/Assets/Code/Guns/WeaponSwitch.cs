using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    public GameObject[] guns;
    public GameObject[] UI;
    private int currentWeapon = 0;
    public AudioSource gun;
    void Start()
    {
        guns[0].gameObject.SetActive(true);
        UI[0].gameObject.SetActive(true);

        guns[1].gameObject.SetActive(false);
        guns[2].gameObject.SetActive(false);
        UI[1].gameObject.SetActive(false);
        UI[2].gameObject.SetActive(false);

    }

    void Update()
    {
    }

    public void change()
    {
        gun.Play();
        currentWeapon++;

        if (currentWeapon < 0)
        {
            currentWeapon = 0;
        }

        if (currentWeapon > 2)
        {
            currentWeapon = 0;
        }

        if (currentWeapon == 0)
        {
            guns[0].gameObject.SetActive(true);
            UI[0].gameObject.SetActive(true);
            guns[1].gameObject.SetActive(false);
            UI[1].gameObject.SetActive(false);
            guns[2].gameObject.SetActive(false);
            UI[2].gameObject.SetActive(false);
        }

        if (currentWeapon == 1)
        {
            guns[0].gameObject.SetActive(false);
            UI[0].gameObject.SetActive(false);
            guns[1].gameObject.SetActive(true);
            UI[1].gameObject.SetActive(true);
            guns[2].gameObject.SetActive(false);
            UI[2].gameObject.SetActive(false);
        }

        if (currentWeapon == 2)
        {
            guns[0].gameObject.SetActive(false);
            UI[0].gameObject.SetActive(false);
            guns[1].gameObject.SetActive(false);
            UI[1].gameObject.SetActive(false);
            guns[2].gameObject.SetActive(true);
            UI[2].gameObject.SetActive(true);
        }
    }
}

