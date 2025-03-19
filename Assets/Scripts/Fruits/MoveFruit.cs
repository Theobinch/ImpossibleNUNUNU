using UnityEngine;

public class MoveFruit : MonoBehaviour
{
    public float speed = 2f; // Vitesse du mouvement
    public float amplitude = 1f; // Hauteur du mouvement

    private Vector3 startPosition;

    //initialise la position de l'objet
    void Start()
    {
        startPosition = transform.position;
    }

    //permet de deplacer l'objet verticalement 
    void Update()
    {
        float newY = startPosition.y + Mathf.Sin(Time.time * speed) * amplitude;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}