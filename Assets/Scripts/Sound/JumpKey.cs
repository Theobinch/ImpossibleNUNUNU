using UnityEngine;

public class JumpKey : MonoBehaviour
{
    public AudioSource audioSource; // Référence au composant AudioSource
    public AudioClip keyPressClip;  // Le clip sonore à jouer
    public KeyCode keyToDetect = KeyCode.Space; // Touche spécifique à détecter (par défaut : barre d'espace)

    void Update()
    {
        // Vérifie si les sons des touches sont activés et si la touche est pressée
        if (AudioSettingsManager.Instance.AreKeySoundsEnabled && Input.GetKeyDown(keyToDetect))
        {
            PlayKeyPressSound();
        }
    }

    void PlayKeyPressSound()
    {
        // Vérifie si un clip est assigné et si AudioSource existe
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