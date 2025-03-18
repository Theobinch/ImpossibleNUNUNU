using UnityEngine;

public class SpikeHeadTrap : MonoBehaviour
{
    public GameObject connectedBloc;
    AudioSource audioSource;
  

    void Start()
    {
        Destroy(gameObject.GetComponent<SpriteRenderer>());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            
            if (audioSource.clip != null)
            {
                audioSource.Play();
            }
         
            connectedBloc.AddComponent<Rigidbody2D>();
            Destroy(gameObject, audioSource.clip.length); 
        }
    }
}