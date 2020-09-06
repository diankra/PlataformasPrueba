using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainCharacter : MonoBehaviour
{
    //public variables
    public float movementSpeed = 2;
    public float jumpHeight = 600f;
    private bool movingRight = false;
    private bool movingLeft = false;
    private bool isJumping = false;
    // Start is called before the first frame update

    //private variables
    private mainCamera camera;

    
    void Start()
    {
        //Change the color to blue
        gameObject.GetComponent<Renderer>().material.color = Color.blue;

        //find the camera
        camera = GameObject.Find("Main Camera").GetComponent<mainCamera>();
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


}

