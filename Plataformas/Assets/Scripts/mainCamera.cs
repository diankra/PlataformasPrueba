using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainCamera : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //These methods are called by the mainCharacter when it moves, so the camera follows it seamlessly
    public void moveLeft( float movementSpeed)
    {
        transform.Translate(transform.InverseTransformDirection(Vector3.left) * movementSpeed * Time.deltaTime);
    }

    public void moveRight(float movementSpeed)
    {
        transform.Translate(transform.InverseTransformDirection(Vector3.right) * movementSpeed * Time.deltaTime);
    }
}
