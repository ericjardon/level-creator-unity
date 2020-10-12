using System.Collections;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;
//using UnityEngine.CoreModule;
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
    public float x;
    public float y;
    public float z;
    public GameObject goodItem;
    public GameObject enemy;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = transform.GetComponent<Rigidbody2D>();
        collider = transform.GetComponent<CapsuleCollider2D>();
        // Si llamamos esta función nos forza a que el player siempre aparezca en el mismo punto restart(x,y,z);
    }
//27.29
    void FixedUpdate(){
    if(!Maker.isPlaying)
    return;

        if (IsGrounded() == true)
        {
            jumps = extraJumps;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(!Maker.isPlaying)
    return;
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
public void restart(float x, float y , float z){
  gameObject.transform.position = new Vector3(x, y,z);

}
    private bool IsGrounded()
    {
        RaycastHit2D raycastHit2d = Physics2D.BoxCast(collider.bounds.center, collider.bounds.size, 0f, Vector2.down, .1f, platformsLayerMask);
        return raycastHit2d.collider != null;
    }

//  private void OnCollisionEnter2D (Collision2D collision)
//  {
//      if (collision.gameObject.tag == "Enemy")
//      {
//         restart(-3,3,0);
//         Destroy(collision.gameObject);
//      }

//       if (collision.gameObject.tag == "Surprise")
//      {


//  Destroy(collision.gameObject);
// if((UnityEngine.Random.Range(0f,1f))>0.5f){
//  Instantiate(goodItem, new Vector3(collision.gameObject.transform.position.x,collision.gameObject.transform.position.y+1,0), Quaternion.identity);
// }

// else{
// Instantiate(enemy, new Vector3(collision.gameObject.transform.position.x,collision.gameObject.transform.position.y+1,0) , Quaternion.identity);

// }
       


       
//      }

     
    
//  }
}



