using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bottomCollider : MonoBehaviour
{
    public GameObject parentBox; 

    private void OnCollisionEnter2D (Collision2D collision){
        if (collision.gameObject.tag == "Player"){
            print("succ");
            parentBox.GetComponent<SurpriseBlock>().Surprise(collision);
        }
    }
}