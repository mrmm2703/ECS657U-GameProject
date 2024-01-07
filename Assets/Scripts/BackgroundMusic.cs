using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public List<AudioClip> songs;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().volume = StorageController.GetBackgroundMusicVolume();
        GetComponent<AudioSource>().Play();
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateVolume(float newVol)
    {
        GetComponent<AudioSource>().volume = newVol;
    }

    public static BackgroundMusic GetControllerInScene()
    {
        return FindFirstObjectByType<BackgroundMusic>();
    }
}
