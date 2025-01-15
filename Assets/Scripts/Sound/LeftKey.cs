using UnityEngine;

public class LeftKey : MonoBehaviour
{
    public AudioSource audioSource; 
    public AudioClip shortPressClip; 
    public AudioClip longPressClip;  

    private float pressTime = 0f;   
    private bool isLongPressPlayed = false; 

    void Update()
    {
        // Vérifier si touche Q ou flèche gauche pressée
        if (Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.LeftArrow))
        {
            pressTime += Time.deltaTime;

            // Jouer son long après 0.6 secondes
            if (pressTime >= 0.6f && !isLongPressPlayed)
            {
                PlayLongPressSound();
                isLongPressPlayed = true; 
            }
        }
        else
        {
            if (pressTime > 0f && pressTime < 2f)
            {
                PlayShortPressSound();
            }
            
            pressTime = 0f;
            isLongPressPlayed = false;
        }
    }

    void PlaySound(AudioClip clip)
    {
        // Utiliser la méthode correcte pour vérifier l'activation des sons des touches
        if (clip != null && audioSource != null && AudioSettingsManager.Instance.AreKeySoundsEnabled)
        {
            audioSource.PlayOneShot(clip);
        }
    }

    void PlayShortPressSound()
    {
        // Utiliser la fonction générique pour jouer un son
        PlaySound(shortPressClip);
    }

    void PlayLongPressSound()
    {
        // Utiliser la fonction générique pour jouer un son
        PlaySound(longPressClip);
    }
}