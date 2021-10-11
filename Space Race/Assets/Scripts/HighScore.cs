using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    public Text high;

    
    void Start()
    {
        high.text = PlayerPrefs.GetInt("highscore") + "";
    }

   
}
