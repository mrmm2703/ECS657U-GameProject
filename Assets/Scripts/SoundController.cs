using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioClip popSound;
    public AudioClip boomSound;
    public AudioClip phewmSound;
    public AudioClip uhhSound;
    public AudioClip clickSound;
    public AudioClip letsGoSound;

    public enum Sound
    {
        Pop,
        Boom,
        Phewm,
        Uhh,
        Click,
        LetsGo
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySound(Sound soundToPlay)
    {
        float fxVol = StorageController.GetSoundEffectsVolume();
        switch (soundToPlay)
        {
            case Sound.Pop:
                PlayAudioClip(popSound, fxVol * 0.5f) ;
                break;
            case Sound.Boom:
                PlayAudioClip(boomSound, fxVol);
                break;
            case Sound.Phewm:
                PlayAudioClip(phewmSound, fxVol);
                break;
            case Sound.Uhh:
                PlayAudioClip(uhhSound, fxVol);
                break;
            case Sound.Click:
                PlayAudioClip(clickSound, fxVol);
                break;
            case Sound.LetsGo:
                PlayAudioClip(letsGoSound, fxVol);
                break;
        }
    }

    private void PlayAudioClip(AudioClip clipToPlay, float volume = 1f)
    {
        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.volume = volume;
        audioSource.Stop();
        audioSource.clip = clipToPlay;
        audioSource.Play();
    }

    public static SoundController GetControllerInScene()
    {
        return FindFirstObjectByType<SoundController>();
    }
}
