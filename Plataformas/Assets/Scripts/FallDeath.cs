using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*! \class FallDeath
 *  \brief This class simulates death by falling. It is associated with an invisible box that triggers the death of the character when touched. 
 *  It would simulate the floor far below. 
 */
public class FallDeath: MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        //this check could be skipped if we were sure only the player will fall down
        if (collision.gameObject.name == "Main Cube") {
            SceneManager.LoadScene("deathScene");
        }
    }
}
