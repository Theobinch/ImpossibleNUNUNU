using UnityEngine;

public class MoveRabbit : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;
    private Rigidbody2D rb;
    public Animator anim;
    private Transform targetPoint;
    public float speed;
    public bool isActive = false;

    //initialisation de la destination (point B)
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        targetPoint = pointB.transform;

        //stop l'animation de course
        if (anim != null)
        {
            anim.SetBool("IsRunning", false);
        }

        rb.linearVelocity = Vector2.zero;
    }

    //si active, alors il se deplace vers le point
    void FixedUpdate()
    {
        if (isActive)
        {
            MoveTowardsTargetPoint();
        }
    }

    //le monstre se deplace vers un point et lance l'anim de course et stop l'anim des qui arrive au point et arrete le script
    private void MoveTowardsTargetPoint()
    {
        if (targetPoint == null)
            return;

        Vector2 direction = (targetPoint.position - transform.position).normalized;
        rb.linearVelocity = new Vector2(direction.x * speed, rb.linearVelocity.y);

        if (anim != null)
        {
            anim.SetBool("IsRunning", true);
        }


        if (Vector2.Distance(transform.position, targetPoint.position) < 0.3f)
        {
            rb.linearVelocity = Vector2.zero;
            if (anim != null)
            {
                anim.SetBool("IsRunning", false);
            }

            this.enabled = false;
        }
    }

    //inflige degat au contact du joueur 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player" ))
        {
            PlayerCollisions playerCollisions = collision.GetComponent<PlayerCollisions>();
            if (playerCollisions != null)
            {
                playerCollisions.TakeDamages(1);
            }
        }
    }

    //dessine les point dans l'editeur pour mieux gerer la distance 
    private void OnDrawGizmos()
    {
        if (pointA != null && pointB != null)
        {
            Gizmos.DrawWireSphere(pointA.transform.position, 0.1f);
            Gizmos.DrawWireSphere(pointB.transform.position, 0.1f);
            Gizmos.DrawLine(pointA.transform.position, pointB.transform.position);
        }
    }
}
