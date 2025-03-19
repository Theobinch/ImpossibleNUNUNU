using UnityEngine;
using System.Collections;

public class WallSpawningSpikeTrapRight : MonoBehaviour
{
    [SerializeField] private GameObject spikes;
    [SerializeField] private float raiseSpeed = 2f; 
    [SerializeField] private float raiseDistance = 0.16f; 

    private bool triggered = false; 
    private Vector3 initialPosition; 
    private Vector3 targetPosition; 

    AudioSource audioSource;

    private void Start()
    {
        initialPosition = spikes.transform.position;

        targetPosition = initialPosition + new Vector3(raiseDistance, 0f, 0f); 

        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !triggered)
        {
            triggered = true;
            StartCoroutine(RaiseWallSpikes()); 
            audioSource.Play();
        }
    }

    private IEnumerator RaiseWallSpikes()
    {
        while (Vector3.Distance(spikes.transform.position, targetPosition) > 0.01f)
        {
            spikes.transform.position = Vector3.MoveTowards(spikes.transform.position, targetPosition, raiseSpeed * Time.deltaTime);
            yield return null;
        }
    }
}