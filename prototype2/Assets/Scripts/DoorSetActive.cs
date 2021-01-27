using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class DoorSetActive : MonoBehaviour, IDoor
{
    /*private IEnumerator WaitForSceneLoad()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("level1");

    }*/

    private Animator animator;
    private bool isOpen = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    //if the door is toggled to open the box collider will become inactive. 
    public void OpenDoor()
    {
        //gameObject.SetActive(false);
        //gameObject.GetComponent<BoxCollider2D>().enabled = false;
        animator.SetBool("Open", true);
        //StartCoroutine(WaitForSceneLoad());
    }

    //if the door is toggled to close the box collider will become active
    public void CloseDoor()
    {
        //gameObject.SetActive(true);
        //gameObject.GetComponent<BoxCollider2D>().enabled = true;
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

