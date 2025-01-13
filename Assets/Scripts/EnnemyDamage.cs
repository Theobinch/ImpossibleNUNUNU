using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollisions : MonoBehaviour
{
    public int life = 1; // Points de vie du joueur
    private bool isDead = false; // Indique si le joueur est mort
    private Animator anim; // Animator pour gérer les animations du joueur

    [Header("Player Settings")]
    public GameObject Player; // Assignez ce GameObject dans l'Inspector

    private void Awake()
    {
        // Récupérer l'Animator depuis le GameObject Player
        if (Player != null)
        {
            anim = Player.GetComponent<Animator>();
            if (anim == null)
            {
                Debug.LogError("Animator component is missing on the Player GameObject.");
            }
        }
        else
        {
            Debug.LogError("Player GameObject is not assigned in the Inspector.");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Détecte si le joueur entre en collision avec un objet portant le tag "Player"
        if (collision.CompareTag("Player"))
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

        // Déclenche l'animation de mort si l'Animator est présent
        if (anim != null)
        {
            anim.SetTrigger("PlayerDie");
            Debug.Log("PlayerDie trigger activated.");
        }
        else
        {
            Debug.LogWarning("Animator component is missing on the Player GameObject.");
        }

        // Redémarre le niveau après un délai
        Invoke("RestartLevel", 1f);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}