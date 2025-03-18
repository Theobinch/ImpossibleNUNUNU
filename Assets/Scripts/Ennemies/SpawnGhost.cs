using UnityEngine;

public class SpawnGhost : MonoBehaviour
{
    public GameObject ghost; 
    private bool ghostActivated = false; 

    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !ghostActivated) 
        {
            ghost.SetActive(true);
            audioSource.Play();
            ghostActivated = true; 
        }
    }
}