using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartManager : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // Check if the "R" key is pressed
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartScene();
        }
    }

    // Method to restart the current scene
    private void RestartScene()
    {
        // Get the name of the current scene
        string currentScene = SceneManager.GetActiveScene().name;
        
        // Load the current scene again to restart it
        SceneManager.LoadScene(currentScene);
    }
}
