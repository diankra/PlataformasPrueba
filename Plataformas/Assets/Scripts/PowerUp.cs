using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{

    //The power up allows the player to kill the enemies (like in Pac-Man)

    public float timeActive = 10; //time the power-up will affect the player in seconds
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
                Destroy(this.gameObject);
            }
        }
    }
}
