using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*! \class PowerUp
 *  \brief This class is associated with the power-up objects placed on the level. These give the player the special power of killing enemies for
 *  a short period of time. The power-ups can only be picked if the player isn't using one already and once picked they destroy themselves. 
 */
public class PowerUp : MonoBehaviour
{
    public float timeActive = 10; //!< This attribute indicates how much time the power-up is active (in seconds)
    // Start is called before the first frame update
    void Start()
    {
        //Change the color to cyan
        gameObject.GetComponent<Renderer>().material.color = Color.cyan;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Main Cube")
        {
            mainCharacter character = other.gameObject.GetComponent<mainCharacter>();
            if (!character.isPowerful())
            {
                character.becomePowerful(timeActive);
                Destroy(gameObject);
            }
        }
    }
}
