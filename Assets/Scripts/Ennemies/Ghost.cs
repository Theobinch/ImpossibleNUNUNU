using UnityEngine;

public class Ghost : MonoBehaviour
{
    public Animator anim; 
    public bool isActive = false; 
    
    //ghost cache au depart
    void Start()
    {
        gameObject.SetActive(false); 
    }

    //fait apparaitre le ghost quand dans la zone et lance l'animation et inflige des degats si necessaire au joeur
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            
            gameObject.SetActive(true); 
            isActive = true; 
            
            if (anim != null)
            {
                anim.SetBool("IsRunning", true);
            }
            
            PlayerCollisions playerCollisions = collision.GetComponent<PlayerCollisions>();
            if (playerCollisions != null)
            {
                playerCollisions.TakeDamages(1);
            }
        }
    }
}