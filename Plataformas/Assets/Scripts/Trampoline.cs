using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*! \class Trampoline
 *  \brief This class is associated with the trampoline platforms. Makes the character jump when stepped on. 
 */
public class Trampoline : MonoBehaviour
{
    public float jumpForce = 700f;//!< This attribute indicates the impulse force the platform will give the character

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.black;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Main Cube")
        {
            collision.gameObject.GetComponent<mainCharacter>().Jump(jumpForce);
        }
    }
}
