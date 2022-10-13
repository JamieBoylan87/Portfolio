using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeSetter : MonoBehaviour
{
    public Rope[] rope;
    private int index = 0;
    private GameObject RopeUI;
    public bool canRope = true;
    public AudioSource ropAudio;
    void Start()
    {
        RopeUI = GameObject.Find("RopeAbilityUI");
    }
    void Update()
    {
        if ((Input.GetMouseButton(0) && Input.GetKey(KeyCode.E)))
        {
            if (canRope == true)
            {
                ropAudio.Play();
                StartCoroutine(RopeTime());
                canRope = false;
                RopeUI.SetActive(false);
                Vector2 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                rope[0].setStart(worldPos);
            }
        }
    }

    public void Death()
    {
        this.enabled = false;
    }

    IEnumerator RopeTime()
    {
        yield return new WaitForSeconds(5f);
        canRope = true;
        RopeUI.SetActive(true);

    }
}
