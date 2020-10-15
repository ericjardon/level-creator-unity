using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snail : MonoBehaviour
{
    public float speed;
    private bool movingRight = true;
    public float rayLength;

    public Transform groundDetection;


    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);        // smoothly moving right according to fps

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, rayLength);

        if(groundInfo.collider == false){     // if the ray hasnt collided with anything, turn character over
            if (movingRight){
                transform.eulerAngles = new Vector3(0,-180,0);
                movingRight = false;
            } else {
                transform.eulerAngles = new Vector3(0,0,0);
                movingRight = true;
            }
        }    
    }
    
    void OnTriggerEnter2D(Collider2D collider){
        Debug.Log("Touched snail");

        if (collider.gameObject.tag == "Player") {
            //collider.gameObject.GetComponent<Player>().enabled = false;
            FindObjectOfType<LeveLoader>().Load();
        }
    }
}
