﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumperPoint : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.yellow;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Main Cube")
        {
            other.gameObject.GetComponent<mainCharacter>().startJumpPoint();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Main Cube")
        {
            other.gameObject.GetComponent<mainCharacter>().endJumpingPoint();
        }
    }
}
