using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
   [SerializeField] private Transform previousRoom;
   [SerializeField] private Transform nextRoom;
   [SerializeField] private CameraController cam;

   private void OnTriggerEnter2D(Collider2D collision)
   {
    Debug.Log("Trigger Entered");

    if(collision.tag == "Player") 
    {
        Debug.Log("Next Area!");
        if(collision.transform.position.x < transform.position.x)
            cam.MoveToNewRoom(nextRoom);

        else
            cam.MoveToNewRoom(previousRoom);
    }
   }
}

