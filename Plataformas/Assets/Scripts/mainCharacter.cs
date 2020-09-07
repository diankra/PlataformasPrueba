using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mainCharacter : MonoBehaviour
{
    //public variables
    public float movementSpeed = 2;
    public float jumpHeight = 600f;
    private bool movingRight = false;
    private bool movingLeft = false;
    private bool isJumping = true;
    public int lives = 3;
    public int spheresToLife = 2; //when the player collects a number of spheres, its life increases

    private Text livesCounter;
    private Text spheresCounter;
    private int spheres = 0;
    // Start is called before the first frame update


    void Start()
    {
        //Change the color to blue
        gameObject.GetComponent<Renderer>().material.color = Color.blue;

        //Initialize the life counter
        livesCounter = GameObject.Find("LivesCounter").GetComponent<Text>();
        livesCounter.text = "Lives: " + lives;
        
        //Initialize the collectable counter
        spheresCounter = GameObject.Find("SpheresCounter").GetComponent<Text>();
        //in case you restart the level

        spheresCounter.text = "Spheres:" + spheres;
    }

    // Update is called once per frame
    void Update()
    {

        if ((movingLeft)||(Input.GetKey(KeyCode.A))) {
            moveLeft();
        }
        if ((movingRight)||(Input.GetKey(KeyCode.D))) {
            moveRight();
        }
        if (Input.GetKeyDown(KeyCode.W)) {
            Jump();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        isJumping = false;
    }

    //methods
    public void moveLeft()
    {
        transform.Translate(transform.InverseTransformDirection(Vector3.left) * movementSpeed * Time.deltaTime);
        
    }

    public void moveRight()
    {
        transform.Translate(transform.InverseTransformDirection(Vector3.right) * movementSpeed * Time.deltaTime);
        
    }

    public void Jump()
    {
        if (!isJumping)
        {
            Rigidbody rigidBody = gameObject.GetComponent<Rigidbody>();
            rigidBody.AddForce(transform.InverseTransformDirection(transform.up) * jumpHeight);
            isJumping = true;
        }
    }

    public void startsMoving(bool right)
    {
        //Method triggered by pressing the bottom part of the screen
        //The most usual direction will be right
        if (right)
        {
            movingRight = true;
        }
        else
        {
            movingLeft = true;
        }
    }

    public void stopsMoving(bool right)
    {
        if (right)
        {
            movingRight = false;
        }
        else
        {
            movingLeft = false;
        }
    }

    public void decreaseLives()
    {
        lives -= 1;
        actualizeLives();
        if (lives == 0)
        {
            //Death
            SceneManager.LoadScene("deathScene");
        }
    }

    public void increaseLives()
    {
        lives += 1;
        actualizeLives();
    }
    public void addSphere()
    {
        spheres += 1;
        if (spheres == spheresToLife)
        {
            increaseLives();
            spheres = 0;
        }
        spheresCounter.text = "Spheres:" + spheres;
    }
    public void actualizeLives()
    {
        livesCounter.text = "Lives: " + lives;
    }
}

