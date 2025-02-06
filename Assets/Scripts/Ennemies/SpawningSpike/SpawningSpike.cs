using UnityEngine;
using System.Collections;

public class SpawningSpike : MonoBehaviour
{
    [SerializeField] private GameObject spikes; // Référence à l'objet pique (cache les piques sous le sol)
    [SerializeField] private float raiseSpeed = 2f; // Vitesse de montée des piques
    [SerializeField] private AudioClip spikeSound; // Son à jouer lors de l'activation
    private AudioSource audioSource; // Composant AudioSource

    private bool triggered = false; // Si le piège a été déclenché
    private Vector3 initialPosition; // Position initiale des piques

    private void Start()
    {
        // Sauvegarder la position initiale des piques sous le sol
        initialPosition = spikes.transform.position;
        
        // Ajouter un AudioSource si ce n'est pas déjà fait
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = spikeSound;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Si le joueur entre dans la zone de détection, activer les piques
        if (collision.CompareTag("Player") && !triggered)
        {
            triggered = true;
            
            // Jouer le son
            if (spikeSound != null && audioSource != null)
            {
                audioSource.Play();
            }
            
            StartCoroutine(RaiseSpikes()); // Lancer la coroutine pour lever les piques
        }
    }

    private IEnumerator RaiseSpikes()
    {
        float targetHeight = initialPosition.y + 0.16f; // Hauteur à laquelle les piques sortent du sol

        // Lever les piques jusqu'à la hauteur cible
        while (spikes.transform.position.y < targetHeight)
        {
            Vector3 currentPos = spikes.transform.position;
            currentPos.y += raiseSpeed * Time.deltaTime; // Déplacer les piques
            spikes.transform.position = currentPos;
            yield return null;
        }
    }
}