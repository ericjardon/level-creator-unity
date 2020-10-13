using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

[System.Serializable]
public struct Block {
    // un esquema que abstrae lo esencial del makerBlock: su posición e id.
    public float x, y, z; 
    public int id;

    public Block(float x, float y, float z, int id) {
        this.x = x;
        this.y = y;
        this.z = z;
        this.id = id;
    }
}


public class LeveLoader : MonoBehaviour
{
    public string path = @"C:\Users\ericj\Desktop\UnityLevels\mylevel.bin";     
    // TODO: accesible on Save pero no on LOAD
    public MakerBlock[] blockPrefabs;   // guardamos los prefabs que se pueden instanciar en el juego
    
    MakerBlock[] levelBlocks;       // en este arreglo se guardan los objetos de un nivel guardado
    
    public void Save() {
        levelBlocks = GameObject.FindObjectsOfType<MakerBlock>();       // busca todos los objetos MakerBlock que existan 
        
        // Convertimos cada uno de estos makerBlocks a estructuras más simples del tipo Block
        // y posteriormente lo guardamos en un archivo
        Block[] savedBlocks = new Block[levelBlocks.Length];        

        for (int i = 0; i < savedBlocks.Length; i++)
        {
            savedBlocks[i] = new Block(levelBlocks[i].transform.position.x,
                                levelBlocks[i].transform.position.y,
                                levelBlocks[i].transform.position.z,
                                levelBlocks[i].id);
        }  // abstrayendo cada makerBlock (gameobject) a un Block (estructura)

        IFormatter formatter = new BinaryFormatter();
        Stream stream = new FileStream(path, 
                                        FileMode.Create,  
                                        FileAccess.Write, 
                                        FileShare.None);
        formatter.Serialize(stream, savedBlocks);
        stream.Close();
        // se guardan los objetos en un archivo
    }

    public void Load(){
        Erase();
        IFormatter formatter = new BinaryFormatter();
        Stream stream = new FileStream(path, 
                                        FileMode.Open,  
                                        FileAccess.Read, 
                                        FileShare.Read);
        
        var objects = (Block[])formatter.Deserialize(stream);
        stream.Close();
        // cargar el archivo y leer los objetos de tipo Block que contiene

        for (int i = 0; i < objects.Length; i++)
        // recorrer todos los objetos Block guardados en el archivo
        {
            Instantiate(blockPrefabs[objects[i].id], 
                        new Vector3(objects[i].x, objects[i].y, objects[i].z), 
                        Quaternion.identity);
            // instantiate the prefab indicated by the Block object's id
        }
    }

    public void Erase(){
        // borra todos los MakerBlocks que existan en escena 
        levelBlocks = GameObject.FindObjectsOfType<MakerBlock>();
        foreach (var i in levelBlocks) {
            Destroy(i.gameObject);
        }
    }

}
