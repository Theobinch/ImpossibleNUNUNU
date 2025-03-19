using UnityEngine;

public class MoveFruitBas : MonoBehaviour
{
    public float speed = 2f; 
    public float amplitude = 1f; 

    private Vector3 startPosition;

    //initialise la position de l'objet
    void Start()
    {
        startPosition = transform.position;
    }

    //permet de faire bouger l'objet verticalement 
    void Update()
    {
        float newY = startPosition.y + Mathf.Sin(Time.time * speed + Mathf.PI) * amplitude;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}