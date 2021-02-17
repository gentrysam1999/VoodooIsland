using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.AI;

public class DoorSetActive : MonoBehaviour, IDoor
{
    private Animator animator;
    private AudioSource door;
    private bool isOpen = false;
    private BoxCollider2D box;
    private NavMeshObstacle navmeshobstacle;

    IEnumerator OpenDelay()
    {
        //yield on a new YieldInstruction that waits for 3 seconds.
        yield return new WaitForSeconds(1);
        navmeshobstacle.enabled = false;
    }

    IEnumerator CloseDelay()
    {
        //yield on a new YieldInstruction that waits for 3 seconds.
        yield return new WaitForSeconds(1);
        navmeshobstacle.enabled = true;
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
        navmeshobstacle = GetComponent<NavMeshObstacle>();
        door = GetComponent<AudioSource>();
    }

    private void Start()
    {
        navmeshobstacle.enabled = true;
    }
    //if the door is toggled to open the door animator will activate.
    public void OpenDoor()
    {
        
        animator.SetBool("Open", true);
        door.Play();
        StartCoroutine(OpenDelay());
        //navmeshobstacle.enabled = false;
    }

    //if the door is toggled to close the animator will go back to idle.
    public void CloseDoor()
    {
        animator.SetBool("Open", false);
        StartCoroutine(CloseDelay());
        //navmeshobstacle.enabled = true;
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


