using UnityEngine;

public class EndGameTrophy : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) ;
        {
            Debug.Log("Le joueur a atteint la fin !");
            FindObjectOfType<ChronoTime>().LoadEndScene();
        }
    }
}