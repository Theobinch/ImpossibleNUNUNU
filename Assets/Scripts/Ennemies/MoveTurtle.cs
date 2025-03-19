using UnityEngine;

public class MoveTurtle : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;
    private Rigidbody2D rb;
    private Animator anim;
    private Transform currentPoint;
    public float speed;

    //initialisation de la destination (point B)
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentPoint = pointB.transform;
        
        //lance l'animation de course
        if (anim != null)
        {
            anim.SetBool("IsRunning", true);
        }
    }

    //deplacement vers les points
    void FixedUpdate()
    {
        MoveTowardsCurrentPoint();
    }

    //permet de faire les alle retour entre chaque point avec un flip
    private void MoveTowardsCurrentPoint()
    {
        Vector2 direction = (currentPoint.position - transform.position).normalized;
        rb.linearVelocity = new Vector2(direction.x * speed, rb.linearVelocity.y);

        if (Vector2.Distance(transform.position, currentPoint.position) < 0.3f)
        {
            currentPoint = currentPoint == pointB.transform ? pointA.transform : pointB.transform;
            Flip();
        }
    }

    //change de direction le monstre avec un flip
    private void Flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    //inflige degat au joueur si il le touche
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

    //permet de dessiner les points A et B dans l'editeur pour mieux gerer la distance 
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