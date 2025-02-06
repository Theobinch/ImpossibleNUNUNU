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
        if ((Input.GetKey(KeyCode.LeftArrow)) || (Input.GetKey(KeyCode.Q)))
        {
            pressTime += Time.deltaTime;

            // Jouer son long après 0.8secondes
            if (pressTime >= 0.8f && !isLongPressPlayed)
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
        if (clip != null && audioSource != null && AudioSettingsManager.Instance.AreKeySoundsEnabled)
        {
            audioSource.PlayOneShot(clip);
        }
    }

    void PlayShortPressSound()
    {
        PlaySound(shortPressClip);
    }

    void PlayLongPressSound()
    {
        PlaySound(longPressClip);
    }
}