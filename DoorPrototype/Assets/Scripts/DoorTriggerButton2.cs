using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTriggerButton2 : MonoBehaviour
{
    public Transform playerTransform;

    // Update is called once per frame
    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.E))
        //{
            float interactRadius = 2f;
            Collider2D[] collider2DArray = Physics2D.OverlapCircleAll(playerTransform.position, interactRadius);
            foreach(Collider2D collider2D in collider2DArray)
            {
                IDoor door = collider2D.GetComponent<IDoor>();
                if(door != null)
                {
                    //there is a door in range
                    door.ToggleDoor();
                }
            }
            
        }
}
