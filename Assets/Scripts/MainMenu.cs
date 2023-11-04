using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private SoundController soundController;
    // Load the next scene in the build index, which is the next level
    public void Play()
    {
        soundController.PlaySound(SoundController.Sound.LetsGo);
        Invoke("OpenGameScene", 1.7f);        
    }

    private void OpenGameScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Quits the application when the Quit button is pressed
    public void Quit()
    {
        soundController.PlaySound(SoundController.Sound.Click);
        Application.Quit();
        Debug.Log("Player has quit the game");
    }

    private void Start()
    {
        soundController = SoundController.GetControllerInScene();
    }
}
