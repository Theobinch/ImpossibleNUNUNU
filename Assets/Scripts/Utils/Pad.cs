using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pad : MonoBehaviour
{
    private float bounce = 5f;

    AudioSource audioSource;

    private void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * bounce, ForceMode2D.Impulse);
            audioSource.Play();
        }
    }
    
}
