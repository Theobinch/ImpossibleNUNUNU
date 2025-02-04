using UnityEngine;
using System.Collections;

public class CeilingSpawningSpikeTrap : MonoBehaviour
{
    [SerializeField] private GameObject spikes; // Référence à l'objet pique (cache les piques dans le plafond)
    [SerializeField] private float dropSpeed = 2f; // Vitesse de descente des piques
    [SerializeField] private float dropDistance = 0.16f; // Distance à parcourir pour que les piques sortent du plafond

    private bool triggered = false; // Si le piège a été déclenché
    private Vector3 initialPosition; // Position initiale des piques
    private Vector3 targetPosition; // Position cible des piques

    private void Start()
    {
        // Sauvegarder la position initiale des piques dans le plafond
        initialPosition = spikes.transform.position;

        // Calculer la position cible des piques (descente)
        targetPosition = initialPosition - new Vector3(0f, dropDistance, 0f); // Descente sur l'axe Y
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Si le joueur entre dans la zone de détection, activer les piques
        if (collision.CompareTag("Player") && !triggered)
        {
            triggered = true;
            StartCoroutine(DropCeilingSpikes()); // Lancer la coroutine pour faire descendre les piques
        }
    }

    private IEnumerator DropCeilingSpikes()
    {
        // Déplacer les piques jusqu'à la position cible
        while (Vector3.Distance(spikes.transform.position, targetPosition) > 0.01f)
        {
            spikes.transform.position = Vector3.MoveTowards(spikes.transform.position, targetPosition, dropSpeed * Time.deltaTime);
            yield return null;
        }
    }
}