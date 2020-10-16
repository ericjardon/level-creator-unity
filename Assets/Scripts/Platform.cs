using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public Transform pos0, pos1;
    public float speed;
    public Transform start;

    Vector3 nextPos;

    void Start(){
        nextPos = start.position;
    }

    void Update(){

        if (transform.position == pos0.position){
            nextPos = pos1.position;
        }

        if (transform.position == pos1.position){
            nextPos = pos0.position;
        }

        transform.position = Vector3.MoveTowards(transform.position, nextPos, speed*Time.deltaTime);
        // MoveTowards moves from a current vector3 position to a target vector3 position,
        // specifying the distance to move per call: for smooth movement we choose a distance 
        // proportional to time passed between frames
    }

    private void OnDrawGizmos(){
        // an implemented method to make drawings based on gizmos in the scene
        // we want to trace a path from gizmo 1 to gizmo 2 so it shows where the platform moves
        Gizmos.DrawLine(pos0.position, pos1.position);
    }

}
