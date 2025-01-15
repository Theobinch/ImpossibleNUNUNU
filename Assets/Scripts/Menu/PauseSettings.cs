using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class PauseSettings : MonoBehaviour
{
    public AudioMixer audioMixer; // Gestionnaire des volumes
    public Slider musicSlider; // Slider pour régler le volume de la musique

    [SerializeField] private TMP_Dropdown resolutionDropdown; // Dropdown pour les résolutions
    [SerializeField] private Toggle keySoundsToggle; // Toggle pour activer/désactiver les sons des touches

    private Resolution[] resolutions; // Toutes les résolutions disponibles
    private List<Resolution> filteredResolutions; // Résolutions filtrées par le taux de rafraîchissement actuel

    private float currentRefreshRate; // Taux de rafraîchissement actuel
    private int currentResolutionIndex = 0; // Index de la résolution actuelle

    void Start()
    {
        // Initialisation des résolutions disponibles et des options
        resolutions = Screen.resolutions;
        filteredResolutions = new List<Resolution>();

        // Récupère le taux de rafraîchissement actuel
        currentRefreshRate = Screen.currentResolution.refreshRate;

        // Filtre les résolutions en fonction du taux de rafraîchissement actuel
        for (int i = 0; i < resolutions.Length; i++)
        {
            if (resolutions[i].refreshRate == currentRefreshRate)
            {
                filteredResolutions.Add(resolutions[i]);
            }
        }

        // Remplir la liste déroulante avec les résolutions filtrées
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

        // Ajouter les options dans le Dropdown
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        // Appliquer le changement de résolution en temps réel
        resolutionDropdown.onValueChanged.AddListener(SetResolution);

        // Initialiser le volume de la musique
        float currentVolume;
        if (audioMixer.GetFloat("MusicVolume", out currentVolume))
        {
            musicSlider.value = Mathf.Pow(10, currentVolume / 20);
        }

        // Ajouter un listener pour gérer les changements de volume
        musicSlider.onValueChanged.AddListener(SetMusicVolume);

        // Initialiser l'état du Toggle pour les sons des touches
        keySoundsToggle.isOn = AudioSettingsManager.Instance.AreKeySoundsEnabled;

        // Ajouter un listener pour gérer les changements du Toggle
        keySoundsToggle.onValueChanged.AddListener(OnKeySoundsToggleChanged);
    }

    // Méthode pour changer la résolution
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = filteredResolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);

        // Log pour vérifier la résolution modifiée
        Debug.Log("Résolution modifiée : " + resolution.width + "x" + resolution.height);
    }

    // Méthode pour ajuster le volume de la musique
    public void SetMusicVolume(float sliderValue)
    {
        float dbVolume = Mathf.Log10(Mathf.Clamp(sliderValue, 0.0001f, 1f)) * 20;
        audioMixer.SetFloat("MusicVolume", dbVolume);
    }

    // Méthode pour gérer les changements du Toggle de sons des touches
    private void OnKeySoundsToggleChanged(bool isEnabled)
    {
        // Mettre à jour l'état global des sons des touches
        AudioSettingsManager.Instance.AreKeySoundsEnabled = isEnabled;
    }
}
