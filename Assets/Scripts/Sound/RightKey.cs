using UnityEngine;

public class RightKey : MonoBehaviour
{
    public AudioSource audioSource; 
    public AudioClip shortPressClip; 
    public AudioClip longPressClip;  

    private float pressTime = 0f;   
    private bool isLongPressPlayed = false; 

    void Update()
    {
        // Vérifier si touche D ou flèche droite pressée
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
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
        // Vérifier si les sons des touches sont activés avant de jouer le son
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