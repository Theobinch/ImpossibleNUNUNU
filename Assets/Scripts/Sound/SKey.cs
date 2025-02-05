using UnityEngine;

public class SKey : MonoBehaviour
{
    public AudioSource audioSource; // Référence au composant AudioSource
    public AudioClip keyPressClip;  // Clip sonore à jouer
    public KeyCode keyToDetect = KeyCode.S; // Touche spécifique à détecter (par défaut : touche S)

    void Start()
    {
        if (audioSource == null)
        {
            Debug.LogError("⚠️ AudioSource n'est pas assigné !");
        }
        
        if (keyPressClip == null)
        {
            Debug.LogError("⚠️ Aucun clip audio n'est assigné !");
        }
        
        // Empêche le son de se jouer au démarrage
        if (audioSource != null)
        {
            audioSource.playOnAwake = false;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(keyToDetect))
        {
            Debug.Log("Touche S pressée"); // Vérifier si le code est bien déclenché

            if (AudioSettingsManager.Instance.AreKeySoundsEnabled)
            {
                PlayKeyPressSound();
            }
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