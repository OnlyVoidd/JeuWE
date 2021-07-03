using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouvement : MonoBehaviour
{
    float inputX;
    [SerializeField]
    private float playerspeed = 1f;
    [SerializeField]
    public float jumpForce = 1f;
    [SerializeField]
    private LayerMask groundLayers;
    [SerializeField]
    private float DashSpeed = 1f;
    [SerializeField]
    private float cooldown = 1f;
    private Rigidbody2D rb;
    public BoxCollider2D col;
    private float NextDash;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        inputX = Input.GetAxisRaw("Horizontal");
        Vector2 movement = new Vector2(playerspeed * inputX, 0);
        NextDash = Time.time + cooldown;
        if (Input.GetButtonDown("Fire1") && Time.time>NextDash )
        {

            transform.Translate(DashSpeed * movement);
         }
        else { 
        
       
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
