using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class SoundEffectsSlider : MonoBehaviour, IPointerUpHandler
{
    public TMP_Text sliderText;
    private SoundController soundController;
    public bool forSoundEffects = false;
    public bool forBackgroundMusic = false;

    public void Start()
    {
        if (forBackgroundMusic)
        {
            GetComponent<Slider>().value = StorageController.GetBackgroundMusicVolume();
            soundController = SoundController.GetControllerInScene();
            sliderText.SetText((StorageController.GetBackgroundMusicVolume() * 100f).ToString("F0") + "%");
        } else if (forSoundEffects)
        {
            GetComponent<Slider>().value = StorageController.GetSoundEffectsVolume();
            soundController = SoundController.GetControllerInScene();
            sliderText.SetText((StorageController.GetSoundEffectsVolume() * 100f).ToString("F0") + "%");
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (forBackgroundMusic)
        {
            StorageController.SetBackgroundMusicVolume(GetComponent<Slider>().value);
            sliderText.SetText((StorageController.GetBackgroundMusicVolume() * 100f).ToString("F0") + "%");
        } else if (forSoundEffects)
        {
            StorageController.SetSoundEffectsVolume(GetComponent<Slider>().value);
            soundController.PlaySound(SoundController.Sound.Phewm);
            sliderText.SetText((StorageController.GetSoundEffectsVolume() * 100f).ToString("F0") + "%");
        }
        
    }

    public void Update()
    {
        //sliderText.SetText((StorageController.GetSoundEffectsVolume() * 100f).ToString("F0") + "%");
    }

    public void OnSliderMove()
    {
        sliderText.SetText((GetComponent<Slider>().value * 100f).ToString("F0") + "%");
    }
}