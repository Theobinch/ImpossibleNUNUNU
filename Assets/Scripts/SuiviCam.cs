using UnityEngine;

using UnityEngine;

public class SuiviCam : MonoBehaviour
{
    public Transform player; // Référence au joueur (assignez-le dans l'Inspector)
    public Vector3 offset;   // Décalage entre la caméra et le joueur
    public float smoothSpeed = 0.125f; // Vitesse de lissage

    void LateUpdate()
    {
        if (player != null)
        {
            // Position cible de la caméra
            Vector3 targetPosition = player.position + offset;

            // Lissage du mouvement de la caméra
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);

            // Mise à jour de la position de la caméra
            transform.position = smoothedPosition;
        }
    }
}
