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

    public static bool isPlaying; 
    public GameObject[] editModeObjects;


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
    public void SwitchPlaying(){
        isPlaying = !isPlaying;
        sprite.enabled = !isPlaying;
        for (int i =0; i < editModeObjects.Length; i++){
            editModeObjects[i].SetActive(!isPlaying);
        } 
    }


    // Update is called once per frame
    void Update()
    {
        if(UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        return;
         if(isPlaying)
        return;

        
        // Get the position of the mouse on the screen 
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        mousePos.x = Mathf.RoundToInt(mousePos.x);
        mousePos.y = Mathf.RoundToInt(mousePos.y);
        sprite.transform.position = mousePos;
        if(Input.GetKeyDown(KeyCode.Mouse0)){
            
            
            var cast = Physics2D.CircleCast(mousePos, 0.4f, Vector2.zero);

            if(cast.collider == null){

                Instantiate(blocks[blockID].gameObject, mousePos, Quaternion.identity);
            }
        }

            if(Input.GetKeyDown(KeyCode.Mouse1)){
            
            
            var cast = Physics2D.CircleCast(mousePos, 0.4f, Vector2.zero);

            if(cast.collider != null){

                Destroy(cast.collider.gameObject);
            }




        
        }

    
    }
}
