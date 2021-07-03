using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouvement : MonoBehaviour
{
    private float inputX;
    [SerializeField]
    private float playerspeed = 1f;
    [SerializeField]
    private float jumpForce = 1f;
    [SerializeField]
    private LayerMask groundLayers;
    [SerializeField]
    private float DashSpeed = 1f;
    [SerializeField]
    private float DashDistance = 3.0f;
    [SerializeField]
    private float cooldown = 1f;
    private Rigidbody2D rb;
    private BoxCollider2D col;
    private float timeSinceLastDash;
    private bool isDashing;
    private float posFinish;
    private float gravity;

    [SerializeField]
    private LayerMask wallLayer;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        gravity = rb.gravityScale;
        col = GetComponent<BoxCollider2D>();
        timeSinceLastDash = Time.time;
    }

    private void OnEnable()
    {
        rb.velocity = Vector2.zero;
        timeSinceLastDash = Time.time;
        isDashing = false;
        rb.gravityScale = gravity;
    }

    // Update is called once per frame
    void Update()
    {
        inputX = Input.GetAxisRaw("Horizontal");


        if(isDashing)
        {
            if (((int) posFinish == (int) transform.position.x) || col.IsTouchingLayers(wallLayer.value))
            {
                rb.velocity = Vector2.zero;
                timeSinceLastDash = Time.time;
                isDashing = false;
                rb.gravityScale = gravity;
            }
        }
        else
        {

            if (Input.GetButtonDown("Fire1") && Time.time - timeSinceLastDash >= cooldown)
            {
                int dir = rb.velocity.x >= 0 ? 1 : -1;

                float posStart = transform.position.x;
                posFinish = posStart + DashDistance*dir;

                
                rb.velocity = new Vector2(DashSpeed*dir, 0);

                isDashing = true;
                rb.gravityScale = 0f;
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




    private bool IsGrounded()
    {
        return Physics2D.IsTouchingLayers(col,groundLayers); 
    }
}
