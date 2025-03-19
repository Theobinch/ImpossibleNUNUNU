using UnityEngine;
using System.Collections;

public class Firetrap : MonoBehaviour
{
    [Header("Firetrap Timers")]
    [SerializeField] private float activationDelay; 
    [SerializeField] private float activeTime; 
    private Animator anim;
    private SpriteRenderer spriteRend;
    private AudioSource audioSource;


    private bool triggered;
    private bool active; 
    private void Awake()
    {
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
    }

    //si joueur touche, active le piege
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!triggered)
            {
                StartCoroutine(ActivateFiretrap());
            }
        }
    }

    //inflige degat au player si il est touche par le piege
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (active && collision.CompareTag("Player"))
        {
            PlayerCollisions pCollision = collision.GetComponent<PlayerCollisions>();
            if (pCollision != null)
            {
                pCollision.TakeDamages(1);
            }
        }
    }

    //gere activation du piege, le son, l'animation et les degats et arrete le piege apres un certain temps 
    private IEnumerator ActivateFiretrap()
    {
        triggered = true;
        spriteRend.color = Color.red; 

        yield return new WaitForSeconds(activationDelay);

        spriteRend.color = Color.white; 
        active = true; 
        anim.SetBool("activated", true); 
        audioSource.Play();

        yield return new WaitForSeconds(activeTime);

        active = false;
        triggered = false; 
        anim.SetBool("activated", false);
    }
}
