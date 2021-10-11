using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardPush : MonoBehaviour
{
    public Rigidbody rb;
    [SerializeField] float ballSpeed = 200f;
    [SerializeField] float speedGain = 5f;
    public Score score;
     

        //GameObjects
    public GameObject restartPanel;
    public GameObject imageScore;
    public GameObject leftButton;
    public GameObject rightButton;
    public GameObject speedParticles;
    public GameObject coinCounter;
    public Transform explosionEffect;
    


    private void Start()
    {
        restartPanel.SetActive(false);
        
        //explosion start status
        explosionEffect.GetComponent<ParticleSystem>().enableEmission = false;
      
    }

   

    void FixedUpdate()
    {
        //forward movement

        
        rb.velocity = transform.forward * ballSpeed;
        
        ballSpeed = ballSpeed + speedGain * Time.deltaTime;

        if (ballSpeed >= 50)
        {
            speedGain = 0;
        }

      

    }

    [System.Obsolete]
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            //player status
            DestroyObject(gameObject);
            ballSpeed = 0;
            speedGain = 0;
           
            

            //restart pannel
            restartPanel.SetActive(true);
            imageScore.SetActive(false);
            leftButton.SetActive(false);
            rightButton.SetActive(false);
            coinCounter.SetActive(false);

            //particles
            speedParticles.SetActive(false);
            explosionEffect.GetComponent<ParticleSystem>().enableEmission = true;

            //score keeper
            Score.pointIncreasePerSecond = 0f;
            Score.pointIncreasePerSecond = 0;
            score.HighscoreUpdate();
            

            //coins calcualtor
            Coin.collisionDetected = true;

            

        }

    }

}