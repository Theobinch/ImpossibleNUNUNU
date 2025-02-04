using UnityEngine;

public class JumpKey : MonoBehaviour
{
    public AudioSource audioSource; 
    public AudioClip keyPressClip;  
    public KeyCode keyToDetect = KeyCode.Space; 

    void Update()
    {
        if (AudioSettingsManager.Instance.AreKeySoundsEnabled && Input.GetKeyDown(keyToDetect))
        {
            PlayKeyPressSound();
        }
    }

    void PlayKeyPressSound()
    {
        if (keyPressClip != null && audioSource != null)
        {
            audioSource.PlayOneShot(keyPressClip);
        }
        else
        {
            Debug.LogWarning("Aucun clip ou AudioSource assigné !");
        }
    }
}