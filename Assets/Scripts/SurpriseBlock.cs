﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurpriseBlock : MonoBehaviour
{

    public GameObject goodItem;
    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     public void Surprise(Collision2D collision){
        if((UnityEngine.Random.Range(0.0f,1.0f))>0.5f){
            Instantiate(goodItem, new Vector3(gameObject.transform.position.x,collision.gameObject.transform.position.y+1,0), Quaternion.identity);
        } 
        else{
            Instantiate(enemy, new Vector3(gameObject.transform.position.x,collision.gameObject.transform.position.y+1,0) , Quaternion.identity);
        }
        Destroy(gameObject);
     }
}