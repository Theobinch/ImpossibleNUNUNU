using UnityEngine;

public class Mob : MonoBehaviour
{
    //detruit pbjet si touche par le joueur
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
