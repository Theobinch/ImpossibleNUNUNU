using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PlayerCollisions : MonoBehaviour
{
    public int life = 1; 
    public bool isDead = false; 
    private Rigidbody2D rb; 
    private Collider2D playerCollider;
    public string Game_Over = "Game_Over";     
    public TextMeshProUGUI deathCountText; 
    public static int deathCount = 0; 

    AudioSource audioSource; 
    public AudioClip audioClip; 
    
    

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();
        audioSource = GetComponent<AudioSource>();
    }
    
    private void Update()
    {
        
        if (deathCountText != null)
        {
            deathCountText.text = "Deaths: " + deathCount; 
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
        if (isDead) return;

        isDead = true;
        deathCount++; 
        ChronoTime chrono = FindObjectOfType<ChronoTime>();
        chrono.StopChrono();

        audioSource.Play();
        
        if (deathCount % 20 == 0 && audioSource != null && audioClip != null)
        {
            audioSource.PlayOneShot(audioClip);
        }

        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero; 
            rb.gravityScale = 2f; 
            rb.constraints = RigidbodyConstraints2D.FreezePositionX; 
           
            rb.linearVelocity = new Vector2(0, 6f); 
            playerCollider.enabled = false;
        }
        
        GameObject cinemachineCamera = GameObject.Find("CinemachineCamera");
        if (cinemachineCamera != null)
        {
            cinemachineCamera.SetActive(false);
        }

        Invoke(nameof(GameOver), 1);
        Invoke("ResetChrono", 1.0f);

    }

        void ResetChrono()
    {
        ChronoTime chrono = FindObjectOfType<ChronoTime>();
        chrono.ResetChrono();

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
