using UnityEngine;

public class SKey : MonoBehaviour
{

    AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
    {
        audioSource.Play();
    }
    }
}
