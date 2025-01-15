using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Parameters")]
    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;

    [Header("Layers")]
    [SerializeField] private LayerMask groundLayer;

    [Header("Sounds")]
    [SerializeField] private AudioClip jumpSound;

    private Rigidbody2D body;
    private Animator anim;
    private BoxCollider2D boxCollider;
    private float horizontalInput;
    private bool isJumping; // Empêche les sauts multiples et la modification du saut en vol
    private bool hasJumped; // Assure qu'on ne saute qu'une seule fois par pression de la touche

    private void Awake()
    {
        // Grab references for Rigidbody and Animator from the object
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        // Mouvement horizontal
        body.linearVelocity = new Vector2(horizontalInput * speed, body.linearVelocity.y);

        // Flip du personnage lorsqu'il change de direction
        if (horizontalInput > 0.01f)
            transform.localScale = Vector3.one;
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);

        // Mise à jour des paramètres de l'animator
        anim.SetBool("PlayerRun", Mathf.Abs(horizontalInput) > 0.01f);
        anim.SetBool("IsGrounded", isGrounded());

        // Gestion du saut
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded() && !hasJumped)
        {
            Jump();
            hasJumped = true; // Marquer qu'un saut a été effectué
        }

        // Ajustement de la hauteur du saut (réduit la vitesse verticale si on relâche la touche)
        if (Input.GetKeyUp(KeyCode.Space) && body.linearVelocity.y > 0)
        {
            body.linearVelocity = new Vector2(body.linearVelocity.x, body.linearVelocity.y * 0.5f);
        }

        // Reset du saut quand le joueur touche le sol
        if (isGrounded())
        {
            hasJumped = false; // Réinitialise la possibilité de sauter après un atterrissage
        }
    }

    private void Jump()
    {
        if (isGrounded()) // Saut uniquement si le joueur est au sol
        {
            body.linearVelocity = new Vector2(body.linearVelocity.x, jumpPower);
            anim.SetTrigger("PlayerJump");
        }
    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(
            boxCollider.bounds.center,
            boxCollider.bounds.size,
            0,
            Vector2.down,
            0.1f,
            groundLayer
        );
        return raycastHit.collider != null;
    }
}
