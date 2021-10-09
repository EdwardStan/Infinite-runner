using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    //floats
    public float speed = 5f;

    //texts
    /*public Text coinDisplay;*/
    public Text totalCoins;

    //statics
    public static int coins = 0;

    public int roundCoins = 0;

    public static bool collisionDetected;



    //coins access
    private void Start()
    {
        coins = PlayerPrefs.GetInt("totalCoins", coins);
        
    }

    
    // Update is called once per frame
    void Update()
    {
        //coin rotation animation
        transform.Rotate(speed, 0, 0);

        //coin display
        /*coinDisplay.text = roundCoins + "";*/


        //coin saver
        if (collisionDetected)
        {
           
            coins = coins + roundCoins;
            PlayerPrefs.SetInt("totalCoins", coins);
            PlayerPrefs.Save();
                
            
        }
    }

    //coin pickup
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Destroy(gameObject);
            
        }

        Score.theScore += 10;
        
        roundCoins ++;
    }


}
