using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouvement : MonoBehaviour
{
    

    [SerializeField]
    private float playerspeed = 1f;
    [SerializeField]
    private float jumpForce = 1f;
    [SerializeField]
    private LayerMask groundLayers;
    [SerializeField]
    private float dashSpeed = 1f;
    [SerializeField]
    private float dashDistance = 3.0f;
    [SerializeField]
    private float dashCooldown = 1f;
    [SerializeField]
    private LayerMask wallLayer;

    private float inputX;
    private Rigidbody2D rb;
    private BoxCollider2D col;
    private float timeSinceLastDash;
    private bool isDashing;
    private float posFinish;
    private float gravity;

    public bool IsDashing
    {
        get => isDashing;
    }



    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        gravity = rb.gravityScale;
        col = GetComponent<BoxCollider2D>();
    }

    private void Start()
    {
        timeSinceLastDash = Time.time;
    }

    private void OnEnable()
    {
        StopDashing();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (col.CompareTag("DashTag") && isDashing) StopDashing();
    }

    // Update is called once per frame
    private void Update()
    {
        inputX = Input.GetAxisRaw("Horizontal");


        if(isDashing)
        {
            if (((int) posFinish == (int) transform.position.x))
            {
                StopDashing();
            }
        }
        else
        {

            if (Input.GetButtonDown("Fire1") && Time.time - timeSinceLastDash >= dashCooldown)
            {
                StartDashing();
            }
            else 
            {
                Vector2 movement = new Vector2(playerspeed * inputX, 0);

                rb.AddForce(movement);

                if (IsGrounded() && Input.GetButtonDown("Jump"))
                {
                    rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                }
            }
        }

    }

    private void StartDashing()
    {
        int dir = rb.velocity.x >= 0 ? 1 : -1;
        float posStart = transform.position.x;
        posFinish = posStart + dashDistance * dir;
        rb.velocity = new Vector2(dashSpeed * dir, 0);
        isDashing = true;
        rb.gravityScale = 0f;
    }

    private void StopDashing()
    {
        rb.velocity = Vector2.zero;
        timeSinceLastDash = Time.time;
        isDashing = false;
        rb.gravityScale = gravity;
    }


    private bool IsGrounded()
    {
        return Physics2D.IsTouchingLayers(col,groundLayers); 
    }
}
