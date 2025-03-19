using UnityEngine;

public class SpikeHead : MonoBehaviour
{
    public GameObject connectedBloc;
    AudioSource audioSource;
  

    //objet devient invisible pour jouer le son
    void Start()
    {
        Destroy(gameObject.GetComponent<SpriteRenderer>());
        audioSource = GetComponent<AudioSource>();
    }

    //si le tag est player : lance un son 
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