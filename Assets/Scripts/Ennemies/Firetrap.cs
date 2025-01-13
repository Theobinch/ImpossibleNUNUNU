using UnityEngine;
using System.Collections;

public class Firetrap : MonoBehaviour
{
    [Header("Firetrap Timers")]
    [SerializeField] private float activationDelay; // Temps avant l'activation
    [SerializeField] private float activeTime; // Durée pendant laquelle le piège reste actif
    private Animator anim;
    private SpriteRenderer spriteRend;

    private bool triggered; // Quand le piège est déclenché
    private bool active; // Quand le piège est actif et peut faire des dégâts

    private void Awake()
    {
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Si c'est le joueur qui entre dans la zone du piège
        if (collision.CompareTag("Player"))
        {
            // Si le piège n'a pas encore été déclenché, on lance l'activation
            if (!triggered)
            {
                StartCoroutine(ActivateFiretrap());
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        // Si le piège est actif et que le joueur est dans la zone
        if (active && collision.CompareTag("Player"))
        {
            // On inflige des dégâts au joueur
            PlayerCollisions pCollision = collision.GetComponent<PlayerCollisions>();
            if (pCollision != null)
            {
                pCollision.TakeDamages(1); // Inflige des dégâts au joueur
            }
        }
    }

    private IEnumerator ActivateFiretrap()
    {
        // Indiquer au joueur que le piège est en train de se déclencher
        triggered = true;
        spriteRend.color = Color.red; // Change la couleur du piège en rouge pour signaler qu'il va se déclencher

        // Attendre le délai d'activation
        yield return new WaitForSeconds(activationDelay);

        // Une fois le délai passé, le piège devient actif
        spriteRend.color = Color.white; // Remet la couleur initiale du piège
        active = true; // Le piège est maintenant actif et peut infliger des dégâts
        anim.SetBool("activated", true); // Active l'animation du piège

        // Attendre la durée pendant laquelle le piège reste actif
        yield return new WaitForSeconds(activeTime);

        // Après le temps d'activation, désactiver le piège
        active = false;
        triggered = false; // Réinitialise l'état du piège
        anim.SetBool("activated", false); // Arrête l'animation
    }
}
