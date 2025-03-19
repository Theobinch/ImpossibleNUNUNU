using UnityEngine;

public class RangedEnnemy : MonoBehaviour
{
    [Header("Attack Parameters")]
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private int damage;
    
    [Header("Ranged Attack")]
    [SerializeField] private Transform firepoint;
    [SerializeField] private GameObject[] bullets;
    
    [Header("Collider Parameters")]
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxCollider;
    
    [Header("Player Layer")]
    [SerializeField] private LayerMask playerLayer;
    private float cooldownTimer = Mathf.Infinity;

    private Animator anim;
    AudioSource audioSource;

    //initialise les son et animation
    private void Awake()
    {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    //attque le joueur quand il est dans la zone du monstre et tire a chaque fin du cooldown
    private void Update()
    {
        cooldownTimer += Time.deltaTime;
        
        if (PlayerInSight())
        {
            if (cooldownTimer >= attackCooldown)
            {
                cooldownTimer = 0;
                anim.SetTrigger("rangedAttack");
            }
        }
    }

    //permet de tirer depuis la position du monstre
    private void RangedAttack()
    {
        cooldownTimer = 0;
        bullets[FindBullet()].transform.position = firepoint.position;
        bullets[FindBullet()].GetComponent<EnnemyProjectile>().ActivateProjectile();
    }

    //joue son si il tire sinon non
    private int FindBullet()
    {
        for (int i = 0; i < bullets.Length; i++)
        {
            if (!bullets[i].activeInHierarchy)
            {
                audioSource.Play();
                return i;
                
            }
        }
        return 0;
    }
    
    //verificiation de la presence du joueur dans la zone 
    private bool PlayerInSight()
    {
        RaycastHit2D hit =
            Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
                new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
                0, Vector2.left, 0, playerLayer);

        return hit.collider != null;
    }
    
    //permet d'afficher la zone en rouge dans l'editeur pour mieux comprendre la portée
    private void OnDrawGizmos()
    {
        if (boxCollider != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
                new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
        }
        else
        {
            Debug.LogWarning("BoxCollider2D is not assigned in RangedEnnemy.");
        }
    }
}
