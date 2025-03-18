using UnityEngine;

public class MoveFruit : MonoBehaviour
{
    public float speed = 2f; // Vitesse du mouvement
    public float amplitude = 1f; // Hauteur du mouvement

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float newY = startPosition.y + Mathf.Sin(Time.time * speed) * amplitude;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}