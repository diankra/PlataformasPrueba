using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*! \class FinishLine
 *  \brief This class is associated with the end of the level. It has a collision that when hit, the level is finished. 
 */
public class FinishLine : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Main Cube")
        {
            SceneManager.LoadScene("winScene");
        }
    }

}
