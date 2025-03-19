using UnityEngine;

public class EndGameTrophy : MonoBehaviour
{
    
    //si joueur touche objet, enregistre le chrono et charge la scene defini dans l'editeur
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) ;
        {
            FindObjectOfType<ChronoTime>().LoadEndScene();
        }
    }
}