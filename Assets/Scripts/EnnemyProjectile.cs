using UnityEngine;

public class EnnemyProjectile : PlayerCollisions
{
    [SerializeField] private float speed;
    [SerializeField] private float resetTime;
    private float lifetime;
    private Animator anim;
    private BoxCollider2D coll;

    private bool hit;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();
    }

    //permet d'actviter et de prendre en compte les collisions
    public void ActivateProjectile()
    {
        hit = false;
        lifetime = 0;
        gameObject.SetActive(true);
        coll.enabled = true;
    }
    
    //deplace le projectile et le supprime apres un certains temps si il n'y a pas eu de colllisions
    private void Update()
    {
        if (hit) return;
        float movementSpeed = speed * Time.deltaTime;
        transform.Translate(new Vector3(-movementSpeed, 0, 0));

        lifetime += Time.deltaTime;
        if (lifetime > resetTime)
            gameObject.SetActive(false);
    }

    //active animation si il touche ou le desactive 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        hit = true;
        base.OnTriggerEnter2D(collision); 
        coll.enabled = false;

        if (anim != null)
            anim.SetTrigger("explode"); 
        else
            gameObject.SetActive(false); 
    }
    
    //rendre l'objet inactif
    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}