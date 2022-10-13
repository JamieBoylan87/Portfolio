using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemiesLeft : MonoBehaviour
{
    public Text enemiesText;
    public int enemies = 15;
    public Canvas canvas;
    public Canvas endScreen;
    public GameObject[] enemy;
    private bool enemy0 = true;
    private bool enemy1 = true;
    private bool enemy2 = true;
    private bool enemy3 = true;
    private bool enemy4 = true;
    private bool enemy5 = true;
    private bool enemy6 = true;
    private bool enemy7 = true;
    private bool enemy8 = true;
    private bool enemy9 = true;
    private bool enemy10 = true;
    private bool enemy11 = true;
    private bool enemy12 = true;
    private bool enemy13 = true;
    private bool enemy14 = true;
    private bool enemy15 = true;
    private bool enemy16 = true;


    void Start()
    {
        canvas.enabled = true;
        endScreen.enabled = false;
        Time.timeScale = 1;
    }

    void Update()
    {
        enemiesLeft();
        if(enemies <= 0)
        {
            canvas.enabled = false;
            endScreen.enabled = true;
            Time.timeScale = .01f;

        }

        if (enemy0 && !enemy[0].activeSelf)
        {
            enemies--;
            enemy0 = false;

        }

        if (enemy1 && !enemy[1].activeSelf)
        {
            enemies--;
            enemy1 = false;

        }
        if (enemy2 && !enemy[2].activeSelf)
        {
            enemies--;
            enemy2 = false;

        }
        if (enemy3 && !enemy[3].activeSelf)
        {
            enemies--;
            enemy3 = false;

        }
        if (enemy4 && !enemy[4].activeSelf)
        {
            enemies--;
            enemy4 = false;

        }
        if (enemy5 && !enemy[5].activeSelf)
        {
            enemies--;
            enemy5 = false;

        }
        if (enemy6 && !enemy[6].activeSelf)
        {
            enemies--;
            enemy6 = false;

        }
        if (enemy7 && !enemy[7].activeSelf)
        {
            enemies--;
            enemy7 = false;

        }
        if (enemy8 && !enemy[8].activeSelf)
        {
            enemies--;
            enemy8 = false;

        }
        if (enemy9 && !enemy[9].activeSelf)
        {
            enemies--;
            enemy9 = false;

        }
        if (enemy10 && !enemy[10].activeSelf)
        {
            enemies--;
            enemy10 = false;

        }
        if (enemy11 && !enemy[11].activeSelf)
        {
            enemies--;
            enemy11 = false;

        }
        if (enemy12 && !enemy[12].activeSelf)
        {
            enemies--;
            enemy12 = false;
        }
        if (enemy13 && !enemy[13].activeSelf)
        {
            enemies--;
            enemy13 = false;
        }
        if (enemy14 && !enemy[14].activeSelf)
        {
            enemies--;
            enemy14 = false;
        }
        if (enemy15 && !enemy[15].activeSelf)
        {
            enemies--;
            enemy15 = false;
        }
        if (enemy16 && !enemy[16].activeSelf)
        {
            enemies--;
            enemy16 = false;
        }

    }

    public void removeEnemy()
    {
        enemies--;
    }
    void enemiesLeft()
    {
        enemiesText.text = string.Format("Enemies: " + enemies);
    }

}
