using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;

    bool moveLeft;
    bool moveRight;
    bool isGrounded;
    float horizontalMove;
    float verticalMove;

    public float speed = 300f;
    public float jumpSpeed = 5;

    [SerializeField] float ballSpeed = 200f;
    [SerializeField] float speedGain = 5f;

    public GameObject restartPanel;
    public GameObject imageScore;
    public GameObject leftButton;
    public GameObject rightButton;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

  public void PointerDownLeft()
    {
        moveLeft = true;
    }
    public void PointerUpLeft()
    {
        moveLeft = false;
    }

    public void PointerDownRight()
    {
        moveRight = true;
    }
    public void PointerUpRight()
    {
        moveRight = false;
    }

    private void Update()
    {
        Movement();
    }

    void Movement()
    {
        if (moveLeft)
        {
            horizontalMove = -speed;
        }
        else if (moveRight)
        {
            horizontalMove = speed;
        }
        else
        {
            horizontalMove = 0;
        }
    }

    public void Jump()
    {
        if (isGrounded)
            {
            rb.AddForce(0, jumpSpeed, 0, ForceMode.Impulse);
            }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(horizontalMove * Time.deltaTime, rb.velocity.y, verticalMove * Time.deltaTime);
        verticalMove = ballSpeed;
        rb.AddForce(0, 0, ballSpeed * Time.deltaTime);
        ballSpeed = ballSpeed + speedGain * Time.deltaTime;

        if (ballSpeed == 400)
        {
            speedGain = 0;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            DestroyObject(gameObject);
            restartPanel.SetActive(true);
            imageScore.SetActive(false);
            Score.pointIncreasePerSecond = 0f;
            Score.collisionDetected = true;
        }
        if (collision.gameObject.tag == "Left Wall")
        {
            leftButton.SetActive(false);
        }

        if (collision.gameObject.tag == "Right Wall")
        {
            rightButton.SetActive(false);
        }


    }

}
