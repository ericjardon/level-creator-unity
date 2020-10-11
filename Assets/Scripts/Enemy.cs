using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform groundDetection; 
     [SerializeField] private LayerMask platformsLayerMask; 
     private BoxCollider2D collider;
    // Start is called before the first frame update
    void Start()
    {
       // rigidbody2D = transform.GetComponent<Rigidbody2D>();
        collider = transform.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, rayLength);

    }

    void FixedUpdate(){
        if(IsGrounded()){
Vector2 movement = new Vector2(0.01f,0);
        transform.Translate(movement);
        }
        else{
            Vector2 movement = new Vector2(-0.01f,0);
        transform.Translate(movement);
        }
        
    }

     private bool IsGrounded()
    {
        RaycastHit2D raycastHit2d = Physics2D.RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, rayLength);

        return raycastHit2d.collider != null;
    }
}
