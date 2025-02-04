using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class PauseSettings : MonoBehaviour
{
    public AudioMixer audioMixer; 
    public Slider musicSlider; 
    [SerializeField] private TMP_Dropdown resolutionDropdown; 
    [SerializeField] private Toggle keySoundsToggle; 

    private Resolution[] resolutions; 
    private List<Resolution> filteredResolutions; 

    private float currentRefreshRate; 
    private int currentResolutionIndex = 0; 

    void Start()
    {
        resolutions = Screen.resolutions;
        filteredResolutions = new List<Resolution>();

        currentRefreshRate = Screen.currentResolution.refreshRate;

        for (int i = 0; i < resolutions.Length; i++)
        {
            if (resolutions[i].refreshRate == currentRefreshRate)
            {
                filteredResolutions.Add(resolutions[i]);
            }
        }

        List<string> options = new List<string>();
        for (int i = 0; i < filteredResolutions.Count; i++)
        {
            string resolutionOption = filteredResolutions[i].width + "x" + filteredResolutions[i].height;
            options.Add(resolutionOption);
            if (filteredResolutions[i].width == Screen.width && filteredResolutions[i].height == Screen.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        resolutionDropdown.onValueChanged.AddListener(SetResolution);

        float currentVolume;
        if (audioMixer.GetFloat("MusicVolume", out currentVolume))
        {
            musicSlider.value = Mathf.Pow(10, currentVolume / 20);
        }

        musicSlider.onValueChanged.AddListener(SetMusicVolume);

        keySoundsToggle.isOn = AudioSettingsManager.Instance.AreKeySoundsEnabled;

        keySoundsToggle.onValueChanged.AddListener(OnKeySoundsToggleChanged);
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = filteredResolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);

        Debug.Log("Résolution modifiée : " + resolution.width + "x" + resolution.height);
    }

    public void SetMusicVolume(float sliderValue)
    {
        float dbVolume = Mathf.Log10(Mathf.Clamp(sliderValue, 0.0001f, 1f)) * 20;
        audioMixer.SetFloat("MusicVolume", dbVolume);
    }

    private void OnKeySoundsToggleChanged(bool isEnabled)
    {

        AudioSettingsManager.Instance.AreKeySoundsEnabled = isEnabled;
    }
}
