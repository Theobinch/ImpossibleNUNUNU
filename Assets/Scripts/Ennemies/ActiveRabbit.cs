using UnityEngine;

public class ActivateRabbit : MonoBehaviour
{
    public MoveRabbit monsterScript; 
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

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