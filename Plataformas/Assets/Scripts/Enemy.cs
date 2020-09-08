using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float distanceRight;
    public float distanceLeft;
    public float speed;
    private float initPosition;
    private Rigidbody rigidBody;


    // Start is called before the first frame update
    void Start()
    {
        //Change the color to red
        gameObject.GetComponent<Renderer>().material.color = Color.red;

        //Set the initial position. It will only move on the horizontal (X) axis, so only the X position is relevant for this
        initPosition = transform.position.x;

        //Initialize the RigidBody component
        rigidBody = GetComponent<Rigidbody>();


    }

    // Update is called once per frame
    void Update()
    {
        //these checks are duplicate code, but they do avoid the enemy from getting stuck when its speed is too high and can't go back
        //to Right or Left position
        if (transform.position.x >= initPosition + distanceRight)
        {
            if (speed > 0)
            {
                speed = speed * -1;
            }
        }
        else if (transform.position.x <= initPosition - distanceLeft)
        {
            if (speed < 0)
            {
                speed = speed * -1;
            }
        }
        rigidBody.velocity = new Vector3(speed, 0, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        speed = 0 - speed;
        if (collision.gameObject.name == "Main Cube")
        {
            mainCharacter mc = collision.gameObject.GetComponent<mainCharacter>();
            if (mc.isPowerful())
            {
                Destroy(this.gameObject);
            } else
                mc.decreaseLives();
        }
        
    }
}
