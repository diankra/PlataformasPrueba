using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



/*! \class mainCharacter 
 *  \brief This class controls the main character and all its variables. Allows the player to control its movement, counts the lives and the collectables and controls the 
 * character's response when interacting with other objects. 
 */
public class mainCharacter : MonoBehaviour
{
    //public attributes

    public float movementSpeed = 2; //!< Sets the character's acceleration when moving left or right.
    public float jumpHeight = 600f; //!< Sets the character's impulse for jumping.
    private bool movingRight = false; //!< Indicates if the right direction button or key is pressed.
    private bool movingLeft = false; //!< Indicates if the left direction button or key is pressed.
    private bool isJumping = true; //!< Indicates if the jump direction button or key is pressed.

    public int lives = 3; //!< Sets the lives the player has. These are decreased when colliding with enemies.
    private int spheres = 0; //!< Private attribute which counts the spheres the player has gathered. 
    public int spheresToLife = 5; //!< Sets the amount of spheres the player has to gather in order to earn an extra life.

    private Rigidbody rigidBody; //!< Rigidbody component needed for movement based on forces.

    private Text livesCounter; //!< Interface component called for showing the number of lives the player has left.
    private Text spheresCounter; //!< Interface component called for showing the number of spheres the player has gathered.
    

    private bool powerful = false; //!< Flag that indicates wether the player has collected a power-up.
    private float startedPower = -1; //!< Private attribute that indicates the time when a power-up has been gathered.
    private float activePower = 0; //!< Attribute that stores the value timeActive of the power-up most recently gathered.

    private int numberJumps = 0; //!< This attribute counts the consecutive jumps the player has done in order to allow double-jump
    // Start is called before the first frame update



    void Start()
    {
        //Change the color to blue
        gameObject.GetComponent<Renderer>().material.color = Color.blue;

        //Initialize the life counter
        livesCounter = GameObject.Find("LivesCounter").GetComponent<Text>();
        livesCounter.text = "Lives: " + lives;

        //Initialize Rigidbody
        rigidBody = gameObject.GetComponent<Rigidbody>();
        //Initialize the collectable counter
        spheresCounter = GameObject.Find("SpheresCounter").GetComponent<Text>();
        //in case you restart the level
        spheresCounter.text = "Spheres:" + spheres;

    }

    // Update is called once per frame
    void Update()
    {
        
        // Movement control 
        //Movement is controlled by invisible buttons (Android) or keyboard keys (for testing in the computer)
        if ((movingLeft) || (Input.GetKey(KeyCode.A)))
        {
            moveLeft();
        }
        if ((movingRight) || (Input.GetKey(KeyCode.D)))
        {
            moveRight();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            Jump();
        }

        //This is only relevant when the player has consumed a power-up
        //Checks if the effect of the power-up has passed
        if (((Time.time - startedPower) >= activePower) && (powerful))
        {
            powerful = false;

            //Change the color to blue
            gameObject.GetComponent<Renderer>().material.color = Color.blue;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //When the character touches the floor, it can no longer be considered to be jumping
        isJumping = false;
        numberJumps = 0;
    }

    private void OnCollisionExit(Collision collision)
    {
        //When the character stops touching the floor, it is considered to be jumping
        isJumping = true;
        numberJumps += 1;
    }

    /**
     * Allows the character to move to the left.
     * Adds an acceleration force in the left hand direction equal to the movementSpeed attribute
     */
    public void moveLeft()
    {
        rigidBody.AddForce(transform.InverseTransformDirection(-transform.right) * movementSpeed, ForceMode.Acceleration);
    }

    /**
     * Allows the character to move to the right.
     * Adds an acceleration force in the right hand direction equal to the movementSpeed attribute
     */
    public void moveRight()
    {
        rigidBody.AddForce(transform.InverseTransformDirection(transform.right) * movementSpeed, ForceMode.Acceleration);

    }

    /**
     * Allows the character to jump.
     * Adds an impulse force upwards equal to the jumpHeight attribute.
     * It first checks that the player is either on the floor or on his first jump. This makes it impossible to jump through the level without
     * touching the floor.
     */
    public void Jump()
    {
        if ((!isJumping) || (numberJumps == 1))
        {
            numberJumps += 1;

            rigidBody.AddForce(transform.InverseTransformDirection(transform.up) * jumpHeight);
            isJumping = true;
        }
    }

    /**
     * Routine called when the player hits a Trampoline. Makes it jump every time it hits these kinds of collisions. 
     * Adds an impulse force upwards equal to the height attribute.
     */
    public void Jump(float height)
    {
        numberJumps += 1;

        rigidBody.AddForce(transform.InverseTransformDirection(transform.up) * height);
        isJumping = true;
    }

    /**
     * Routine called when the character is close to a Jumping Point. 
     * It allows one extra jump only when the Jumping Point is close. 
     */
    public void startJumpPoint()
    {
        isJumping = false;
    }

    /**
     * Routine called when the character is no longer close to a Jumping Point. 
     * It indicates that the character can no longer use the extra jump the Jumping Point allows. 
     */
    public void endJumpingPoint()
    {
        isJumping = true;
    }

    /**
     * Method triggered when one of the movement buttons is pressed. 
     * The button indicates wether it is the right or the left one using the boolean right. 
     * Activates the corresponding movement flag, allowing the player to move in the indicated direction until the button is no longer pressed. 
     */
    public void startsMoving(bool right)
    {
        if (right)
        {
            movingRight = true;
        }
        else
        {
            movingLeft = true;
        }
    }

    /**
     * Method triggered when one of the movement buttons stops being pressed. 
     * The button indicates wether it is the right or the left one using the boolean right. 
     * Deactivates the corresponding movement flag, so that the character stops moving in that direction. 
     */
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

    /**
     * Method triggered when the player collides with an enemy. 
     * Decreases in one the lives the player has left. If after that, there are zero lives, it shows the death screen. 
     */
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

    /**
    * Method triggered when the player steps on a collectable sphere. 
    * Adds one collectable to the counter. Checks if there are enough spheres to add one life to the player.  
    */
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

    /**
     * Method called when the player has gathered enough collectable spheres. 
     * Adds one to the total of lives. 
     */
    public void increaseLives()
    {
        lives += 1;
        actualizeLives();
    }

    /**
     * Method used to actualize the number of lives shown on the UI. 
     * Can be called either from decreaseLives() or from increaseLives()
     */
    public void actualizeLives()
    {
        livesCounter.text = "Lives: " + lives;
    }

    /**
     * Method triggered when the player collides with a power-up. 
     * Activates the powerful flag, which allows the player to kill the enemies in the same way as Pac-man. 
     * Sets the time the power-up has been taken and the duration it has, so that the power-up can be deactivated when its time
     * runs out. Changes the main character's color to cyan, so that the player knows when they are powerfull and when the effects have passed
     */
    public void becomePowerful(float timeActive)
    {
        powerful = true;
        startedPower = Time.time;
        activePower = timeActive;

        gameObject.GetComponent<Renderer>().material.color = Color.cyan;
    }

    /**
     * Checks wether the powerful flag is active. 
     * It is called by the power-up to avoid taking one when the player is already powerfull. 
     */
    public bool isPowerful()
    {
        return powerful;
    }


}

