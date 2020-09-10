using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*! \class Collectable
 *  \brief This class is associated with the collectable spheres. When they are picked, they self-destruct. If the player collects a certain number of
 *  them, they give them an extra life. 
 */
public class Collectable : MonoBehaviour
{
   
    private Text counter;
    // Start is called before the first frame update
    void Start()
    {
        //Change the color to green
        gameObject.GetComponent<Renderer>().material.color = Color.green;

       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Main Cube")
        {
            other.gameObject.GetComponent<mainCharacter>().addSphere();
            Destroy(gameObject);
        }
    }
}
