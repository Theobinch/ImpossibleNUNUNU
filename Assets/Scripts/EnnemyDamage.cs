using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PlayerCollisions : MonoBehaviour
{
    public int life = 1; 
    private bool isDead = false; 
    private Rigidbody2D rb; 
    private Collider2D playerCollider;
    public string Game_Over = "GameOverScene"; 
    [SerializeField] public float fallLimit;
    public TextMeshProUGUI deathCountText;
    
    public static int deathCount = 0; 

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();
    }
    
    private void Update()
    {
        if (transform.position.y < fallLimit && !isDead)
        {
            Die();
        }
        
        if (deathCountText != null)
        {
            deathCountText.text = "Deaths: " + deathCount;  // Affiche le nombre de morts
        }
        else
        {
            Debug.LogWarning("Death Count Text is not assigned in the Inspector!");
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ennemy"))
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
        deathCount++; 
        
        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero; 
            rb.gravityScale = 2f; 
            rb.constraints = RigidbodyConstraints2D.FreezePositionX; 
           
            rb.linearVelocity = new Vector2(0, 6f); 
            playerCollider.enabled = false;
        }

        Invoke(nameof(GameOver), 1);
    }

    public void GameOver()
    {
        SceneManager.LoadScene(Game_Over);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }
}
