using UnityEngine;

public class SpawnGhost : MonoBehaviour
{
    public GameObject ghost; 
    private bool ghostActivated = false; 

    public AudioSource audioSource; 
    public AudioClip activationSound;

    void Start()
    {

        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        audioSource.clip = activationSound;
        audioSource.playOnAwake = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !ghostActivated) 
        {
            ghost.SetActive(true); 
            ghostActivated = true; 
     
            if (audioSource.clip != null)
            {
                audioSource.Play();
            }
        }
    }
}