using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollisions : MonoBehaviour
{
    public int life = 1;
    private bool isDead = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            TakeDamages(1);
        }
    }

    public void TakeDamages(int damage)
    {
        life -= damage;

        if (life <= 0 && !isDead)
        {
            Die();
        }
    }

    public void Die()
    {
        isDead = true;

        // Optionnel : Ajouter un effet visuel de mort ici
        GetComponent<Rigidbody2D>().AddForce(Vector3.up * 150);
        GetComponent<Collider2D>().isTrigger = true;

        Invoke("RestartLevel", 0); // Laisse un délai avant de redémarrer le niveau
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
