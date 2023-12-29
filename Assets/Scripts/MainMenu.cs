using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private SoundController soundController;

    // Load the next scene in the build index, which is the next level
    public void Play()
    {
        Debug.Log("Play button pressed");
        AudioSource audioSource = GetComponent<AudioSource>();
        soundController.PlaySound(SoundController.Sound.LetsGo);

        StartCoroutine(WaitForSoundAndLoadScene(audioSource.clip.length));

    }


    private IEnumerator WaitForSoundAndLoadScene(float delay)
    {
        yield return new WaitForSecondsRealtime(delay);
        SceneManager.LoadScene("MapOne");
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

    public static void ChangeSoundEffectsVolume(Slider slider)
    {
        StorageController.SetSoundEffectsVolume(slider.value);
    }
}
