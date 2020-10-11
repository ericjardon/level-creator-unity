using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Maker : MonoBehaviour
{
    // Array of all the tiles to instatiate
    public MakerBlock[] blocks;

    // Reference to our button prefab;
    public GameObject button;

    // Reference to the layout
    public Transform layout;

    // Reference to the id of the button to instatiate 
    int blockID;

    // Reference to the sprite
    public SpriteRenderer sprite;

    


    // Start is called before the first frame update
    void Start()
    {
         
        for (int i = 0 ; i < blocks.Length; i++){
            int u = i;
            var theBlock = Instantiate(button, layout);
            theBlock.GetComponent<Image>().sprite = blocks[u].sprite;
            theBlock.GetComponent<Button>().onClick.AddListener(()=>{
                blockID = u;
                sprite.sprite = blocks[u].sprite;
            });
        }  
    }

    // Update is called once per frame
    void Update()
    {
        // Get the position of the mouse on the screen 
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        mousePos.x = Mathf.RoundToInt(mousePos.x);
        mousePos.y = Mathf.RoundToInt(mousePos.y);

        if(Input.GetKeyDown(KeyCode.Mouse0)){
            Instantiate(blocks[blockID].gameObject, mousePos, Quaternion.identity);
        }

        sprite.transform.position = mousePos;
    }
}
