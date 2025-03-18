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


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        targetPoint = pointB.transform;


        if (anim != null)
        {
            anim.SetBool("IsRunning", false);
        }

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
