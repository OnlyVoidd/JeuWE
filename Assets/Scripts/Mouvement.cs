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
    private float cooldown = 1f;
    private Rigidbody2D rb;
    private BoxCollider2D col;
    private float timeSinceLastDash;
    private float distance;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();
        timeSinceLastDash = Time.time;
    }

    // Update is called once per frame
    void Update()
    {   

        if (Input.GetButtonDown("Fire1") && Time.time - timeSinceLastDash >= cooldown)
        {

            int dir = inputX >= 0 ? 1 : -1;
            transform.Translate(DashSpeed * new Vector2(dir,0));
            timeSinceLastDash = Time.time;
        }
        else 
        {
            
            inputX = Input.GetAxisRaw("Horizontal");
            Vector2 movement = new Vector2(playerspeed * inputX, 0);

            rb.AddForce(movement);

            if (IsGrounded() && Input.GetButtonDown("Jump"))
            {
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
        }

    }


    private bool IsGrounded()
    {
        return Physics2D.IsTouchingLayers(col,groundLayers); 
    }
}
