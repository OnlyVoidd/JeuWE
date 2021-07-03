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
    private Rigidbody2D rb;
    public BoxCollider2D col;
    public LayerMask groundLayers; 
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
       Vector2 movement = new Vector3(playerspeed * inputX, 0);
       rb.AddForce(movement);
       if (IsGrounded() && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
       Debug.Log(IsGrounded());

    }


    private bool IsGrounded()
    {
        return Physics.CheckCapsule(col.bounds.center, new Vector2(col.bounds.center.x,
            col.bounds.min.y),col.shapeCount,groundLayers);
        
       
    }
}
