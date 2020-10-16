using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    public int value = 10;

    private void OnTriggerEnter2D(Collider2D other){
        Debug.Log("Trigger");
        if (other.gameObject.CompareTag("Player")){
            Debug.Log("Touched player");
            GemCounter.instance.AddGem(value);
        }
    }
}
