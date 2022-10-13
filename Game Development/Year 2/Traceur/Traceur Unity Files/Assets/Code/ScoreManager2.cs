using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager2 : MonoBehaviour
{
    public static ScoreManager2 instance;
    private int timer;
    public Text scoreText;
    public Text highscoreText;

    public int score = 0;
    public int highscore2 = 100;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        highscore2 = PlayerPrefs.GetInt("highscore2", 0);
        scoreText.text = score.ToString() + " SECONDS";
        highscoreText.text = "FASTEST: " + highscore2.ToString();
        InvokeRepeating("AddPoint", 1, 1);
    }

    public void AddPoint()
    {
        score += 1;
        scoreText.text = score.ToString() + " POINTS";
    }    

    public void checkHighscore()
    {
        if ((highscore2 > score) || (highscore2 == 0))
        {
            PlayerPrefs.SetInt("highscore2", score);
        }
    }
}
