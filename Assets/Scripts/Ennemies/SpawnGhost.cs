using UnityEngine;

public class SpawnGhost : MonoBehaviour
{
    public GameObject ghost; // Référence au GameObject fantôme
    private bool ghostActivated = false; // Pour éviter d'activer plusieurs fois

    // Cette fonction est appelée lorsqu'un objet entre dans la zone de trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !ghostActivated) // Vérifie si c'est le joueur
        {
            ghost.SetActive(true); // Active le fantôme
            ghostActivated = true; // Empêche d'activer à nouveau le fantôme
        }
    }
}