using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Transform playerTransform;
    public Animator animator; 
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void onTriggerEnter(Collider other)
    {
        //if (other.CompareTag("Player"))
        //{
            //GUI.Label(new Rect(0, -200, Screen.width, Screen.height), "hits left");
            //if (Input.GetKeyDown(KeyCode.F))
            //{
                //gameObject.GetComponent<BoxCollider2D>().enabled = false;
                animator.SetBool("Open", true);
            //}
        //}
    }

    void onTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //gameObject.GetComponent<BoxCollider2D>().enabled = false;
            animator.SetBool("Open", false);
        }
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
