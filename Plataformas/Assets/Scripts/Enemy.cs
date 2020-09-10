using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*! \class Enemy
 *  \brief This class controls the enemies. It sets their movements, speed and collisions. 
 *  The enemies move between two points continuously. They change direction if they collide with any other object so that they don't get stuck. 
 *  When hitting the character, they can either die (if a power-up is active) or take lives from it.
 */
public class Enemy : MonoBehaviour
{
    public float distanceRight; //!< Distance they reach moving to the rigt direction from their starting point. 
    public float distanceLeft;//!< Distance they reach moving to the left direction from their starting point. 
    public float speed; //!< This attribute indicates their speed of movement. 
    private float initPosition; //!< This attribute stores their initial X position (as it is the only one that changes).
    private Rigidbody rigidBody; //!< Rigidbody component attached to the enemy.  


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
