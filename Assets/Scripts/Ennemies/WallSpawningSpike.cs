using UnityEngine;
using System.Collections;

public class WallSpawningSpikeTrap : MonoBehaviour
{
    [SerializeField] private GameObject spikes; // Référence à l'objet pique (cache les piques dans le mur)
    [SerializeField] private float raiseSpeed = 2f; // Vitesse de sortie des piques
    [SerializeField] private float raiseDistance = 0.16f; // Distance à parcourir pour que les piques sortent du mur

    private bool triggered = false; // Si le piège a été déclenché
    private Vector3 initialPosition; // Position initiale des piques
    private Vector3 targetPosition; // Position cible des piques

    private void Start()
    {
        // Sauvegarder la position initiale des piques dans le mur
        initialPosition = spikes.transform.position;

        // Calculer la position cible des piques (sortie du mur)
        targetPosition = initialPosition + new Vector3(-raiseDistance, 0f, 0f); // Supposons que le mur est aligné sur l'axe X
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Si le joueur entre dans la zone de détection, activer les piques
        if (collision.CompareTag("Player") && !triggered)
        {
            triggered = true;
            StartCoroutine(RaiseWallSpikes()); // Lancer la coroutine pour sortir les piques
        }
    }

    private IEnumerator RaiseWallSpikes()
    {
        // Déplacer les piques jusqu'à la position cible
        while (Vector3.Distance(spikes.transform.position, targetPosition) > 0.01f)
        {
            spikes.transform.position = Vector3.MoveTowards(spikes.transform.position, targetPosition, raiseSpeed * Time.deltaTime);
            yield return null;
        }
    }
}