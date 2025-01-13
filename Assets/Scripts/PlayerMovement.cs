using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;       // Vitesse horizontale
    [SerializeField] private float jumpForce;   // Force du saut
    private Rigidbody2D body;
    private Animator anim;
    private bool IsGrounded;

    private void Awake()
    {
        // Récupérer les composants nécessaires
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        // Mouvement horizontal
        body.linearVelocity = new Vector2(horizontalInput * speed, body.linearVelocity.y);

        // Inverser le personnage lorsqu'il se déplace à gauche/droite
        if (horizontalInput > 0.01f)
            transform.localScale = Vector3.one;
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);

        // Gestion du saut
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded)
        {
            Jump();
        }

        // Mise à jour des paramètres de l'Animator
        anim.SetBool("PlayerRun", horizontalInput != 0);
        anim.SetBool("IsGrounded", IsGrounded);
    }

    private void Jump()
    {
        // Appliquer une force vers le haut pour le saut
        body.linearVelocity = new Vector2(body.linearVelocity.x, jumpForce);
        anim.SetTrigger("PlayerJump");
        IsGrounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Vérifier si le joueur touche le sol
        if (collision.gameObject.CompareTag("Ground"))
        {
            IsGrounded = true;
        }
    }
}