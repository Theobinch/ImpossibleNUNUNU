using UnityEngine;
using System.Collections;

public class CeilingSpawningSpikeTrap : MonoBehaviour
{
    [SerializeField] private GameObject spikes; 
    [SerializeField] private float dropSpeed = 2f; 
    [SerializeField] private float dropDistance = 0.16f; 

    private bool triggered = false;
    private Vector3 initialPosition; 
    private Vector3 targetPosition; 

    private void Start()
    {
        initialPosition = spikes.transform.position;
        targetPosition = initialPosition - new Vector3(0f, dropDistance, 0f); 
    }

    //si joueur touche le piege, active le piege 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !triggered)
        {
            triggered = true;
            StartCoroutine(DropCeilingSpikes()); 
        }
    }

    //active les piege jusqua leur point de destination 
    private IEnumerator DropCeilingSpikes()
    {
        while (Vector3.Distance(spikes.transform.position, targetPosition) > 0.01f)
        {
            spikes.transform.position = Vector3.MoveTowards(spikes.transform.position, targetPosition, dropSpeed * Time.deltaTime);
            yield return null;
        }
    }
}