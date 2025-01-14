using UnityEngine;

public class Ghost : MonoBehaviour
{
    public Animator anim; // Animator public
    public bool isActive = false; // Cette variable contrôle si le fantôme doit être actif

    void Start()
    {
        // Le fantôme ne doit pas être visible tant qu'il n'est pas activé
        gameObject.SetActive(false); // Cache le fantôme au départ
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Faire apparaître le fantôme quand le joueur entre dans la zone
            gameObject.SetActive(true); // Faire apparaître le fantôme
            isActive = true; // Le fantôme est maintenant actif

            // Lancer l'animation du fantôme si elle existe
            if (anim != null)
            {
                anim.SetBool("IsRunning", true);
            }

            // Appliquer des dégâts au joueur si nécessaire
            PlayerCollisions playerCollisions = collision.GetComponent<PlayerCollisions>();
            if (playerCollisions != null)
            {
                playerCollisions.TakeDamages(1);
            }
        }
    }
}