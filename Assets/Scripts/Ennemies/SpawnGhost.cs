using UnityEngine;

public class SpawnGhost : MonoBehaviour
{
    public GameObject ghost; 
    private bool ghostActivated = false; // ghost non visible au debut 
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    
    //booleen du ghost, apparait si le tag est "joueur" et lance le son
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