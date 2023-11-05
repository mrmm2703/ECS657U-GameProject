using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool paused;
    public GameObject PauseMenuPanel;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (paused) 
            {
                Play();
            }
            else
            {
                Stop();
            }
        }
    }

    void Stop()
    {
        PauseMenuPanel.SetActive(true);
        Time.timeScale = 0.0f;
        paused = true;
    }

    public void Play()
    {
        PauseMenuPanel.SetActive(false);
        Time.timeScale = 1.0f;
        paused = false;
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene(0);
    }
}
