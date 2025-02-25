using UnityEngine;

public class MoveTurtle : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;
    private Rigidbody2D rb;
    private Animator anim;
    private Transform currentPoint;
    public float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentPoint = pointB.transform;

        // Démarrage de l'animation de mouvement
        if (anim != null)
        {
            anim.SetBool("IsRunning", true);
        }
    }

    void FixedUpdate()
    {
        MoveTowardsCurrentPoint();
    }

    private void MoveTowardsCurrentPoint()
    {
        // Calculer la direction du mouvement
        Vector2 direction = (currentPoint.position - transform.position).normalized;

        // Appliquer la vitesse au Rigidbody
        rb.linearVelocity = new Vector2(direction.x * speed, rb.linearVelocity.y);

        // Vérifier si la tortue a atteint le point cible
        if (Vector2.Distance(transform.position, currentPoint.position) < 0.3f)
        {
            // Changer la direction et le point cible
            currentPoint = currentPoint == pointB.transform ? pointA.transform : pointB.transform;
            Flip();
        }
    }

    private void Flip()
    {
        // Inverser la direction en retournant l'échelle locale en X
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Récupère le script PlayerCollisions et applique les dégâts
            PlayerCollisions playerCollisions = collision.GetComponent<PlayerCollisions>();
            if (playerCollisions != null)
            {
                playerCollisions.TakeDamages(1);
            }
        }
    }

    private void OnDrawGizmos()
    {
        // Dessiner les points A et B dans l'éditeur
        if (pointA != null && pointB != null)
        {
            Gizmos.DrawWireSphere(pointA.transform.position, 0.1f);
            Gizmos.DrawWireSphere(pointB.transform.position, 0.1f);
            Gizmos.DrawLine(pointA.transform.position, pointB.transform.position);
        }
    }
}