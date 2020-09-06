using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public void startGame() {
        SceneManager.LoadScene("gameScene");
    }

    public void stopGame() {
        SceneManager.LoadScene("menuScene");
    }

    public void quitGame() {
        Application.Quit();
    }
}
