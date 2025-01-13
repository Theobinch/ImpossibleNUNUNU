using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer; 
    public Slider musicSlider;   

    void Start()
    {
        float currentVolume;
        if (audioMixer.GetFloat("MusicVolume", out currentVolume))
        {
            musicSlider.value = Mathf.Pow(10, currentVolume / 20);
        }
        
        musicSlider.onValueChanged.AddListener(SetMusicVolume);
    }

    public void SetMusicVolume(float sliderValue)
    {
        float dbVolume = Mathf.Log10(Mathf.Clamp(sliderValue, 0.0001f, 1f)) * 20;
        audioMixer.SetFloat("MusicVolume", dbVolume);
    }
}