using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    public static SettingsManager Instance;

    public bool isSoundEnabled = true;
    public bool isMusicEnabled = true;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    // Sauvegarder les paramètres
    public void SaveSettings()
    {
        PlayerPrefs.SetInt("SoundEnabled", isSoundEnabled ? 1 : 0);
        PlayerPrefs.SetInt("MusicEnabled", isMusicEnabled ? 1 : 0);
        PlayerPrefs.Save();
    }
    
    // Charger les paramètres
    public void LoadSettings()
    {
        isSoundEnabled = PlayerPrefs.GetInt("SoundEnabled", 1) == 1;
        isMusicEnabled = PlayerPrefs.GetInt("MusicEnabled", 1) == 1;
    }
}

