using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer; 
    public Slider musicSlider; 

    [SerializeField] private Toggle effectsToggle; 
   
    //barre de son qui permet de modifier le volume grace a un mixeur present dans l'editeur 
    void Start()
    {
        float currentVolume;
        if (audioMixer.GetFloat("MusicVolume", out currentVolume))
        {
            musicSlider.value = Mathf.Pow(10, currentVolume / 20);
        }

        musicSlider.onValueChanged.AddListener(SetMusicVolume);

        effectsToggle.isOn = true;
        effectsToggle.onValueChanged.AddListener(SetEffectsVolume);
    }

    //permet de modifier le volume des sons en jeu 
    public void SetMusicVolume(float sliderValue)
    {
        float dbVolume = Mathf.Log10(Mathf.Clamp(sliderValue, 0.0001f, 1f)) * 20;
        audioMixer.SetFloat("MusicVolume", dbVolume);
    }

    //permet d'activer ou non les effets en jeu 
    private void SetEffectsVolume(bool isOn)
    {
        if (!isOn)
        {
            audioMixer.SetFloat("EffectsVolume", -80f);
        }
        else
        {
            audioMixer.SetFloat("EffectsVolume", 0f);
        }
    }
}
