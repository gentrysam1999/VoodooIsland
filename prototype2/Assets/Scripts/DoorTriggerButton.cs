using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTriggerButton : MonoBehaviour
{
    public DoorSetActive door;
    public Transform playerTransform;

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        { 
                    door.OpenDoor();
            
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            door.CloseDoor();
        }
    }
}
