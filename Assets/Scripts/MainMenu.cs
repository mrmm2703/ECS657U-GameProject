using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Load the next scene in the build index, which is the next level
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }

    // Quits the application when the Quit button is pressed
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Player has quit the game");
    }
}
