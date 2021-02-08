using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class DoorSetActive : MonoBehaviour, IDoor
{
    private Animator animator;
    private bool isOpen = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    //if the door is toggled to open the door animator will activate.
    public void OpenDoor()
    {
        animator.SetBool("Open", true);
    }

    //if the door is toggled to close the animator will go back to idle.
    public void CloseDoor()
    {
        animator.SetBool("Open", false);
    }

    public void ToggleDoor()
    {
        isOpen = !isOpen;
        if (isOpen)
        {
            OpenDoor();
        }
        else
        {
            CloseDoor();
        }
    }
}


