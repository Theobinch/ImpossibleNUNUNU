
using UnityEngine;

public class DisparitionObj : MonoBehaviour
{
    public int requiredBlocks = 1; // Nombre de blocs requis pour détruire cet objet
    private int currentBlockCount = 0; // Compteur des blocs atteints

    // Appelée lorsqu'une collision ou un trigger est détecté
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Vérifie si le joueur touche un bloc (vérifiez que les blocs ont un tag spécifique)
        if (collision.CompareTag("Block"))
        {
            currentBlockCount++; // Incrémente le compteur

            // Si le joueur a atteint 3 blocs, détruisez cet objet
            if (currentBlockCount >= requiredBlocks)
            {
                Destroy(gameObject); // Détruit cet objet
            }
        }
    }
}