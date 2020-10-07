using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
public GameObject EndScreen;
    
    public float speed;     // how fast
    public float jumpForce; // how high
    private float moveInput;

    private Rigidbody2D rb;

    private bool facingRight = true;
    
    
    private bool isGrounded;		// for checking if player is in mid-air or not
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    public int extraJumpsInput;
    private int extraJumps;

    

    // Start is called before the first frame update
    void Start()
    {
        extraJumps = extraJumpsInput
;
        rb = GetComponent<Rigidbody2D>();   // no hace llamada explícita a GameObject
    }
    
    void FixedUpdate()  
    {

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);      // builtin function

        moveInput = Input.GetAxis("Horizontal");        // built-in Unity field. Corresponds to left/arrow keys.     
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);     // y component shall not be influenced by left/right keys
        if ((!facingRight && moveInput > 0) || (facingRight && moveInput <0)){     // When facing left and right arrow is pressed
            Flip();
        } 
    }

    void Update(){

        if (isGrounded){
            extraJumps = extraJumpsInput;
        }
        // check each frame if player hits 'Up' arrow.
        if( Input.GetKeyDown(KeyCode.UpArrow) && extraJumps > 0 ){ 
            rb.velocity = Vector2.up * jumpForce;       // Vector2.up is a unit vector upwards?
            extraJumps --;
        } else if( Input.GetKeyDown(KeyCode.UpArrow) && extraJumps==0 && isGrounded ){
            rb.velocity = Vector2.up * jumpForce;
        }
    }

    void Flip() {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale; // the player's x,y,z scale values.
        Scaler.x *= -1;
        transform.localScale = Scaler;      // flip on x axis and reassign the scale of sprite.
    }
}
