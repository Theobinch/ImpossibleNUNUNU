using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pad : MonoBehaviour
{
    private float bounce = 5f;
    AudioSource audioSource;

    //ajout audio source pour le bounce
    private void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    //si joueur touche, rebondit et joue le son
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * bounce, ForceMode2D.Impulse);
            audioSource.Play();
        }
    }
    
}
