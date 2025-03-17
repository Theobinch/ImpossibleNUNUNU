using UnityEngine;

public class SpawnGhost : MonoBehaviour
{
    public GameObject ghost; 
    private bool ghostActivated = false; 

    void Start()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !ghostActivated) 
        {
            ghost.SetActive(true); 
            ghostActivated = true; 
        }
    }
}