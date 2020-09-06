using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainCamera : MonoBehaviour
{
    private GameObject cube;
    // Start is called before the first frame update
    void Start()
    {
        cube = GameObject.Find("Main Cube");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(cube.transform.position.x, transform.position.y, transform.position.z);
    }

    
}
