﻿using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Parameters")]
    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;

    [Header("Layers")]
    [SerializeField] private LayerMask groundLayer;

    private Rigidbody2D body;
    private Animator anim;
    private CircleCollider2D boxCollider;
    private float horizontalInput;
    private bool isJumping; 
    private bool hasJumped; 
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<CircleCollider2D>();
    }

    //permet de deplacer le joueur horizontalemet, de le faire sauter, et ajouster ses mouvements 
    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        body.linearVelocity = new Vector2(horizontalInput * speed, body.linearVelocity.y);

        if (horizontalInput > 0.01f)
            transform.localScale = Vector3.one;
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);

        anim.SetBool("PlayerRun", Mathf.Abs(horizontalInput) > 0.01f);
        anim.SetBool("IsGrounded", isGrounded());

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)  && isGrounded() && !hasJumped)
        {
            Jump();
            hasJumped = true;
        }

        if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.UpArrow) && body.linearVelocity.y > 0)
        {
            body.linearVelocity = new Vector2(body.linearVelocity.x, body.linearVelocity.y * 0.5f);
        }

        if (isGrounded())
        {
            hasJumped = false; 
        }
    }

    //permet de faire sauter le player en verifiant si il est bien au sol
    private void Jump()
    {
        if (isGrounded()) 
        {
            body.linearVelocity = new Vector2(body.linearVelocity.x, jumpPower);
            anim.SetTrigger("PlayerJump");
        }
    }

    //verification si le joueur est bien sur le sol 
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
