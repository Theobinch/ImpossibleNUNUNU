using UnityEngine;

public class SpikeHeadTrap : MonoBehaviour
{
    public GameObject connectedBloc;
    AudioSource audioSource;
  

    void Start()
    {
        Destroy(gameObject.GetComponent<SpriteRenderer>());
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            audioSource.Play();
            connectedBloc.AddComponent<Rigidbody2D>();
            Destroy(gameObject, audioSource.clip.length); 
        }
    }
}