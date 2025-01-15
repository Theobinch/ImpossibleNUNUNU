using UnityEngine;

public class ActivateRabbit : MonoBehaviour
{
    public MoveRabbit monsterScript; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (monsterScript != null)
            {
                monsterScript.isActive = true; // Active rabbit
                
                if (monsterScript.anim != null)
                {
                    monsterScript.anim.SetBool("IsRunning", true); // Lance l'animation de course
                }
            }
        }
    }
}