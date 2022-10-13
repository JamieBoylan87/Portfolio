using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager1 : MonoBehaviour
{
    public static ScoreManager1 instance;
    private int timer;
    public Text scoreText;
    public Text highscoreText;

    public int score = 0;
    public int highscore1 = 100;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        highscore1 = PlayerPrefs.GetInt("highscore1", 0);
        scoreText.text = score.ToString() + " SECONDS";
        highscoreText.text = "FASTEST: " + highscore1.ToString();
        InvokeRepeating("AddPoint", 1, 1);
    }

    public void AddPoint()
    {
        score += 1;
        scoreText.text = score.ToString() + " POINTS";
    }    

    public void checkHighscore()
    {
        if ((highscore1 > score) || (highscore1 == 0))
        {
            PlayerPrefs.SetInt("highscore1", score);
        }
    }
}
