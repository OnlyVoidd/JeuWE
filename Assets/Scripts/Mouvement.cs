using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouvement : MonoBehaviour
{
    [SerializeField]
    private float playerspeed = 1f;
                            
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        
        Vector3 movement = new Vector3(playerspeed * inputX, 0, 0);
        movement *= Time.deltaTime;
        transform.Translate(movement);
    }
}
