using UnityEngine;

public class SpikeHeadTrap : MonoBehaviour
{
    public GameObject connectedBloc;
    public AudioSource audioSource;  // Source audio
    public AudioClip activationSound; // Son d'activation du piège

    void Start()
    {
        Destroy(gameObject.GetComponent<SpriteRenderer>());

        // Vérifie et ajoute un AudioSource si nécessaire
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        audioSource.clip = activationSound;
        audioSource.playOnAwake = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Joue le son d'activation du piège
            if (audioSource.clip != null)
            {
                audioSource.Play();
            }

            // Active le piège après un court délai pour laisser le son se jouer
            connectedBloc.AddComponent<Rigidbody2D>();
            Destroy(gameObject, audioSource.clip.length); // Détruit après le son
        }
    }
}