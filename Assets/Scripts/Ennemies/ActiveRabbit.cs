using UnityEngine;

public class ActiveRabbit : MonoBehaviour
{
    public MoveRabbit monsterScript; 
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    //lance le son et l'animation lorsque le joueur passe dans la zone d'activation 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (monsterScript != null)
            {
                monsterScript.isActive = true;
                audioSource.Play();
                
                if (monsterScript.anim != null)
                {
                    monsterScript.anim.SetBool("IsRunning", true);
                }
            }
        }
    }
}