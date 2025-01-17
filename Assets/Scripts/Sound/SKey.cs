using UnityEngine;

public class SKey : MonoBehaviour
{
    public AudioSource audioSource; // Référence au composant AudioSource
    public AudioClip keyPressClip;  // Le clip sonore à jouer
    public KeyCode keyToDetect = KeyCode.S; // Touche spécifique à détecter (par défaut : touche S)

    void Update()
    {
        // Vérifier si la touche spécifique est pressée
        if (Input.GetKeyDown(keyToDetect))
        {
            // Vérifier si les sons sont activés avant de jouer le son
            if (AudioSettingsManager.Instance.AreKeySoundsEnabled)
            {
                PlayKeyPressSound();
            }
        }
    }

    void PlayKeyPressSound()
    {
        // Vérifier si un clip est assigné
        if (keyPressClip != null && audioSource != null)
        {
            audioSource.PlayOneShot(keyPressClip); // Joue le son une seule fois
        }
        else
        {
            Debug.LogWarning("Aucun clip ou AudioSource assigné !");
        }
    }
}