using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pad : MonoBehaviour
{
    private float bounce = 5f;

    AudioSource audioSource;
    [SerializeField] private AudioClip padSound;

    private void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = padSound;


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * bounce, ForceMode2D.Impulse);
            audioSource.PlayOneShot(padSound);
        }
    }
    
}
