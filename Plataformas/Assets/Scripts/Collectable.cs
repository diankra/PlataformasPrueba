using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    private static int collected = 0;
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
            collected += 1;
            Debug.Log("Collecionados: " + collected);
            Destroy(gameObject);
        }
    }
}
