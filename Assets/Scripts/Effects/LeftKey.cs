using UnityEngine;

public class LeftKey : MonoBehaviour
{
    public AudioSource audioSource; // Référence au composant AudioSource
    public AudioClip shortPressClip; // Son pour une pression courte
    public AudioClip longPressClip;  // Son pour une pression longue

    private float pressTime = 0f;    // Temps écoulé depuis que la touche est pressée
    private bool isLongPressPlayed = false; // Indicateur pour éviter de rejouer le son long

    void Update()
    {

        if (Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.LeftArrow))
        {
            pressTime += Time.deltaTime;
            
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

    void PlayShortPressSound()
    {
        if (shortPressClip != null && audioSource != null)
        {
            audioSource.PlayOneShot(shortPressClip);
        }
    }

    void PlayLongPressSound()
    {
        if (longPressClip != null && audioSource != null)
        {
            audioSource.PlayOneShot(longPressClip);
        }
    }
}