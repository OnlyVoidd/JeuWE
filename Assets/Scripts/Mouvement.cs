using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouvement : MonoBehaviour
{
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

        float inputX = Input.GetAxisRaw("Horizontal");
        Vector3 movement = new Vector3(playerspeed * inputX * Time.deltaTime, 0, 0);
        rb.AddForce(movement)
        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(movement, ForceMode2D.Impulse);
        }
        
        

    }


    private void FixedUpdate()
    {
            

    }
}
