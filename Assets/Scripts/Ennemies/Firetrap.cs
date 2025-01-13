using UnityEngine;
using System.Collections;

public class Firetrap : MonoBehaviour
{
    [Header("Firetrap Timers")]
    [SerializeField] private float activationDelay; // Temps avant l'activation
    [SerializeField] private float activeTime; // Durée pendant laquelle le piège est actif
    private Animator anim;
    private SpriteRenderer spriteRend;
    private bool triggered; // Si le piège a été déclenché
    private bool active; // Si le piège est actif et peut tuer le joueur

    private void Awake()
    {
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!triggered)
                StartCoroutine(ActivateFiretrap());

            // Si le piège est actif, tuer le joueur en utilisant EnemyDamage
            if (active)
            {
             
                // die
                
            }
        }
    }

    private IEnumerator ActivateFiretrap()
    {
        triggered = true;

        // Animation ou délai avant l'activation
        yield return new WaitForSeconds(activationDelay);

        active = true;

        // Animation ou actions pendant que le piège est actif
        yield return new WaitForSeconds(activeTime);

        // Désactiver le piège
        active = false;
        triggered = false;
    }
}