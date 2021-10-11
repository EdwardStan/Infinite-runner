using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    
    public static float theScore;
    public static float pointIncreasePerSecond;
    public static bool collisionDetected = false;
    
    public Text finalScore;
    public Text scoreText;
    
    public GameObject highScore;

    public int highscore = 0;

 

    void Start()
    {
        theScore = 0f;
        pointIncreasePerSecond = 3f;
        highscore = PlayerPrefs.GetInt("highscore", highscore);
    }

    void Update()
    {
        scoreText.text = (int)theScore + "";
        theScore += pointIncreasePerSecond * Time.deltaTime;

        

        finalScore.text = (int)theScore + "";
    }
    
    public void HighscoreUpdate()
    {
        if ((int)theScore > highscore)
        {
            highscore = (int)theScore;
            PlayerPrefs.SetInt("highscore", highscore);
            PlayerPrefs.Save();
            highScore.SetActive(true);
        }
    }
}
