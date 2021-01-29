using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimCtrl : MonoBehaviour
{
    // Speed of the movement
    public float speed = 5f;

    public Rigidbody2D rb;

    private Vector2 movement;

    public Animator anim;

    public float animCtrl = 0f;

    // Direction of the movement
    //private float movementDirX;
    //private float movementDirY;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //float userInputX = Input.GetAxis("Horizontal");
        //float userInputY = Input.GetAxis("Vertical");

        // Get the direction of the movement from the sign
        // of the axis input (-ve is left, +ve is right)
        //movementDirX = Mathf.Sign(userInputX);
        //movementDirY = Mathf.Sign(userInputY);

        // Move the game object
        //if (userInputX != 0 || userInputY !=0){
        //Vector3 playerMove = new Vector3(userInputX*speed*Time.deltaTime, userInputY*speed*Time.deltaTime, 0);
        //transform.position = transform.position+playerMove;
        //}


        if (movement.x == 0 && movement.y == 0)
        {
            anim.SetInteger("animCtrl", 0);
            Debug.Log("not moving");
        }
        else
        {
            anim.SetInteger("animCtrl", 1);
            Debug.Log("moving");
        }


        
    }

    void FixedUpdate()
    {
        //Debug.Log(rb.position + movement * speed * Time.fixedDeltaTime);
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
}
