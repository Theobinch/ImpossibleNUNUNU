using UnityEngine;

public class SpikeHeadTrap : MonoBehaviour
{
    public GameObject connectedBloc;


    void Start()
    {
        Destroy(gameObject.GetComponent<SpriteRenderer>());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            connectedBloc.AddComponent<Rigidbody2D>();
            Destroy(gameObject);
        }
    }

}
