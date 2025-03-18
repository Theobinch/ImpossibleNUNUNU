using UnityEngine;
using System.Collections;

public class SpawningSpike : MonoBehaviour
{
    [SerializeField] private GameObject spikes; 
    [SerializeField] private float raiseSpeed = 2f; 
    private AudioClip spikeSound; 
    private AudioSource audioSource;

    private bool triggered = false;
    private Vector3 initialPosition; 

    private void Start()
    {
        initialPosition = spikes.transform.position;
        
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = spikeSound;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !triggered)
        {
            triggered = true;
            
            if (audioSource != null && spikeSound != null)
            {
                audioSource.PlayOneShot(spikeSound);
            }
            
            StartCoroutine(RaiseSpikes());
        }
    }

    private IEnumerator RaiseSpikes()
    {
        float targetHeight = initialPosition.y + 0.16f; 

        while (spikes.transform.position.y < targetHeight)
        {
            Vector3 currentPos = spikes.transform.position;
            currentPos.y += raiseSpeed * Time.deltaTime;
            spikes.transform.position = currentPos;
            yield return null;
        }
    }
}