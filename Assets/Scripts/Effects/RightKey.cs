using UnityEngine;

public class RightKey : MonoBehaviour
{
    public AudioSource audioSource; // Référence au composant AudioSource
    public AudioClip shortPressClip; // Son pour une pression courte
    public AudioClip longPressClip;  // Son pour une pression longue

    private float pressTime = 0f;    // Temps écoulé depuis que la touche est pressée
    private bool isLongPressPlayed = false; // Indicateur pour éviter de rejouer le son long

    void Update()
    {
        // Vérifier si la touche D ou flèche droite est pressée
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            pressTime += Time.deltaTime;

            // Jouer le son long après 2 secondes
            if (pressTime >= 0.6f && !isLongPressPlayed)
            {
                PlayLongPressSound();
                isLongPressPlayed = true; // Marquer comme déjà joué
            }
        }
        else
        {
            // Si la touche est relâchée
            if (pressTime > 0f && pressTime < 2f)
            {
                PlayShortPressSound();
            }

            // Réinitialiser les variables
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