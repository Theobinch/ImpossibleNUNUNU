using UnityEngine;

public class MoveRabbit : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;
    private Rigidbody2D rb;
    public Animator anim; // Animator public
    private Transform targetPoint;
    public float speed;
    public bool isActive = false; // Cette variable doit être publique

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        targetPoint = pointB.transform;
        
        if (anim != null)
        {
            anim.SetBool("IsRunning", false);
        }

        // Deplace pas tant que c'est pas activé
        rb.linearVelocity = Vector2.zero;
    }

    void FixedUpdate()
    {
        if (isActive) 
        {
            MoveTowardsTargetPoint();
        }
    }

    private void MoveTowardsTargetPoint()
    {
        if (targetPoint == null)
            return;

        // Calcule direction mouvement
        Vector2 direction = (targetPoint.position - transform.position).normalized;

        // Vitesse Rigidbody
        rb.linearVelocity = new Vector2(direction.x * speed, rb.linearVelocity.y);

        // Vérification si cible à atteint le point 
        if (Vector2.Distance(transform.position, targetPoint.position) < 0.3f)
        {
            // Arrêter mouvement et désactiver animation
            rb.linearVelocity = Vector2.zero;
            if (anim != null)
            {
                anim.SetBool("IsRunning", false);
            }

            // Désactive le script pour éviter de continuer à bouger
            this.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerCollisions playerCollisions = collision.GetComponent<PlayerCollisions>();
            if (playerCollisions != null)
            {
                playerCollisions.TakeDamages(1);
            }
        }
    }

    private void OnDrawGizmos()
    {
        // Dessiner les points A et B 
        if (pointA != null && pointB != null)
        {
            Gizmos.DrawWireSphere(pointA.transform.position, 0.1f);
            Gizmos.DrawWireSphere(pointB.transform.position, 0.1f);
            Gizmos.DrawLine(pointA.transform.position, pointB.transform.position);
        }
    }
}
