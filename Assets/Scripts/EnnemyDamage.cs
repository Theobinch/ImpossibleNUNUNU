using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollisions : MonoBehaviour
{
    public int life = 1; // Points de vie du joueur
    private bool isDead = false; // Indique si le joueur est mort
    private Rigidbody2D rb; // Référence au Rigidbody2D du joueur
    private Collider2D playerCollider;
    public string Game_Over = "GameOverScene"; // Nom de la scène Game Over

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        // Détecte si le joueur entre en collision avec un objet portant le tag "Enemy"
        if (collision.CompareTag("Ennemy")) // Assurez-vous d'utiliser le bon tag
        {
            TakeDamages(1);
        }
    }

    public void TakeDamages(int damage)
    {
        // Réduit la vie du joueur et vérifie si elle atteint zéro
        life -= damage;

        if (life <= 0 && !isDead)
        {
            Die();
        }
    }

    public void Die()
    {
        isDead = true;

        // Désactiver tout mouvement du joueur
        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero; // Stopper tout mouvement
            rb.gravityScale = 2f; // Assure que la gravité agit normalement
            rb.constraints = RigidbodyConstraints2D.FreezePositionX; // Bloque le mouvement horizontal

            // Ajoute un saut vertical
            rb.linearVelocity = new Vector2(0, 6f); // Définit une vitesse verticale pour le saut
            playerCollider.enabled = false;
        }

        GameOver(); // Appelle la méthode pour changer de scène
    }

    public void GameOver()
    {
        // Chargement de la scène Game Over

        SceneManager.LoadScene(Game_Over);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Recharge la scène actuelle
    }
}
