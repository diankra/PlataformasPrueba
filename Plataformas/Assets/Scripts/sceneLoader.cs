using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/*! \class sceneLoader
 *  \brief This class contains methods to start, stop and quit the game. It is called from the buttons on the interface
 */
public class sceneLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /**
     * It is triggered when the player presses Play or any of its variants in the menus. Loads the game scene so that it can start
     */
    public void startGame() {
        SceneManager.LoadScene("gameScene");
    }

    /**
     * It's triggered when the player presses the quit button on the screen. Returns to the menu scene. 
     */
    public void stopGame() {
        SceneManager.LoadScene("menuScene");
    }

    /**
     * It's triggered when the player presses Quit on the menu. Stops the application.
     */
    public void quitGame() {
        Application.Quit();
    }
}
