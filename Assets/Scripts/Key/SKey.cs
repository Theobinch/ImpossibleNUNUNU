using UnityEngine;

public class SKey : MonoBehaviour
{

    AudioSource audioSource;
    
    //ajoute un audio source
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    //si touche S pressé, joue le son 
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
    {
        audioSource.Play();
    }
    }
}
