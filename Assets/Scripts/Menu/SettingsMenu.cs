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

    public void SetMusicVolume(float sliderValue)
    {
        float dbVolume = Mathf.Log10(Mathf.Clamp(sliderValue, 0.0001f, 1f)) * 20;
        audioMixer.SetFloat("MusicVolume", dbVolume);
    }

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
