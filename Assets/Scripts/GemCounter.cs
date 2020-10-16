using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GemCounter : MonoBehaviour
{
    public static GemCounter instance;

    public Text text;

    int pts;

    void Start(){
        if (instance==null){
            instance = this;
        }

    }

    public void AddGem(int val){
        Debug.Log("Adding Gem");
        pts += val;
        text.text = "X" + pts.ToString();
    }

    public void RestartCount(){
        pts = 0;
        text.text = "X0";
    }
    
}
