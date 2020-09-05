using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainCharacter : MonoBehaviour
{
    public float movementSpeed = 2;
    public float jumpHeight = 600f;
    // Start is called before the first frame update
    void Start()
    {
        //Change the color to blue
        gameObject.GetComponent<Renderer>().material.color = Color.blue; 
    }

    // Update is called once per frame
    void Update()
    {
        //to test movement ERASE WHEN MOBILE CONTROLS
        if (Input.GetKey(KeyCode.A)) {
            moveLeft();
        }
        if (Input.GetKey(KeyCode.D)) {
            moveRight();
        }
        if (Input.GetKeyDown(KeyCode.W)) {
            Jump();
        }
    }

    public void moveLeft() {
        transform.Translate(Vector3.left * movementSpeed * Time.deltaTime);
    }

    public void moveRight() {
        transform.Translate(Vector3.right * movementSpeed * Time.deltaTime);
    }

    public void Jump() {
        Rigidbody rigidBody = gameObject.GetComponent<Rigidbody>();
        rigidBody.AddForce(transform.up * jumpHeight);
    }
}
