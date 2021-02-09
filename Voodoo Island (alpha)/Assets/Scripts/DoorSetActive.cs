using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.AI;

public class DoorSetActive : MonoBehaviour, IDoor
{
    private Animator animator;
    private bool isOpen = false;

    private NavMeshObstacle navmeshobstacle;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        navmeshobstacle = GetComponent<NavMeshObstacle>();
    }

    private void Start()
    {
        navmeshobstacle.enabled = true;
    }
    //if the door is toggled to open the door animator will activate.
    public void OpenDoor()
    {
        navmeshobstacle.enabled = false;
        animator.SetBool("Open", true);
    }

    //if the door is toggled to close the animator will go back to idle.
    public void CloseDoor()
    {
        navmeshobstacle.enabled = true;
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


