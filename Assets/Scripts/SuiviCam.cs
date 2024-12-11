using UnityEngine;

public class SuiviCam : MonoBehaviour
{
    public Transform player; // Référence au joueur (assignez-le dans l'Inspector)
    public Vector3 offset = new Vector3(0, 0, -10); // Décalage caméra-joueur (Z doit être négatif)
    public float smoothSpeed = 0.125f; // Vitesse de lissage (réduction de secousses)

    void LateUpdate()
    {
        if (player != null)
        {
            // Calcul de la position cible
            Vector3 targetPosition = player.position + offset;

            // Lissage du mouvement de la caméra
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);

            // Mise à jour de la position de la caméra
            transform.position = smoothedPosition;
        }
    }
}