using System.Collections;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;
using System;
using System.Runtime.InteropServices;
using Debug = UnityEngine.Debug;

public class Player_B : MonoBehaviour
{
    [SerializeField] private LayerMask platformsLayerMask; 
    private Rigidbody2D rigidbody2D;
    private CapsuleCollider2D collider;
    public int extraJumps;
    public int jumps;
    public float jumpForce;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = transform.GetComponent<Rigidbody2D>();
        collider = transform.GetComponent<CapsuleCollider2D>();
    }

    void FixedUpdate(){
        if (IsGrounded() == true)
        {
            jumps = extraJumps;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
        float horizontal = Input.GetAxis("Horizontal"); /// Va de los valores-1 a 1
        float vertical = Input.GetAxis("Vertical");
        horizontal = horizontal * 1 / 25;
        vertical = vertical * 1 / 50;
        gameObject.transform.Translate(new Vector2(horizontal, 0));

        

        if (Input.GetKeyDown(KeyCode.Space) && jumps > 0)
        {
                Debug.Log(jumps);
                float jumpV = jumpForce;
                rigidbody2D.velocity = Vector2.up * jumpV;
                jumps --;
                Debug.Log(jumps);

        }
        
    }

    private bool IsGrounded()
    {
        RaycastHit2D raycastHit2d = Physics2D.BoxCast(collider.bounds.center, collider.bounds.size, 0f, Vector2.down, .1f, platformsLayerMask);
        return raycastHit2d.collider != null;
    }
}