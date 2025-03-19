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
         float savedMusicVolume = PlayerPrefs.GetFloat("MusicVolume", 1f);
        musicSlider.value = savedMusicVolume;
        SetMusicVolume(savedMusicVolume);

        bool savedEffectsOn = PlayerPrefs.GetInt("EffectsOn", 1) == 1;
        effectsToggle.isOn = savedEffectsOn;
        SetEffectsVolume(savedEffectsOn);

        musicSlider.onValueChanged.AddListener(SetMusicVolume);
        effectsToggle.onValueChanged.AddListener(SetEffectsVolume);
    }

    //permet de modifier le volume des sons en jeu 
    public void SetMusicVolume(float sliderValue)
    {
        float dbVolume = Mathf.Log10(Mathf.Clamp(sliderValue, 0.0001f, 1f)) * 20;
        audioMixer.SetFloat("MusicVolume", dbVolume);

        PlayerPrefs.SetFloat("MusicVolume", sliderValue);
        PlayerPrefs.Save();
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

        PlayerPrefs.SetInt("EffectsOn", isOn ? 1 : 0);
        PlayerPrefs.Save();
    }
}
