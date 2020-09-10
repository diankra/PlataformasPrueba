using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*! \class SlipperyPlatform
 *  \brief This class differenciates the slippery platforms giving them the color grey. The slippery features are given instead by a Phisycs Material. 
 */
public class SlipperyPlatform : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.grey;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
