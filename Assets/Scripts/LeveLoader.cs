using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Block {
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
    public string path = @"C:\Users\ericj\Desktop\UnityLevels";
    // el nombre de usuario deberá cambiar según la computadora, i.e. reemplazar 'ericj'
    public MakerBlock[] blockPrefabs;
    MakerBlock[] levelBlocks;
    /*
    public void Save() {
        MakerBlock[] makerBlocks = GameObject.FindObjectsOfType<MakerBlock>();
        Block[] savedBlocks = new Block[makerBlocks.Length];

        for (int i = 0; i < savedBlocks.Length; i++)
        {
            savedBlocks[i] = new Block(makerBlocks[i].transform.position.x,
                                makerBlocks[i].transform.position.y,
                                makerBlocks[i].transform.position.z,
                                makerBlocks[i].id);
        }

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

        IFormatter formatter = new BinaryFormatter();
        Stream stream = new FileStream(path, 
                                        FileMode.Open,  
                                        FileAccess.Read, 
                                        FileShare.Read);
        formatter.Serialize(stream, savedBlocks);
        
        var theBlock = (Block[])formatter.Deserialize(stream);
        stream.Close();
        // cargar el archivo
        for (int i = 0; i < length; i++)
        {
            // min 35:42
            return;

        }
    }*/
}
