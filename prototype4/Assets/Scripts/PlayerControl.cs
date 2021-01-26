using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    // Speed of the movement
   public float speed;
   
   // Direction of the movement
   //private float movementDirX;
   //private float movementDirY;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void fixedUpdate(){

        
    }

    // Update is called once per frame
    void Update()
    {
        float userInputX = Input.GetAxis("Horizontal");
        float userInputY = Input.GetAxis("Vertical");

        // Get the direction of the movement from the sign
        // of the axis input (-ve is left, +ve is right)
        //movementDirX = Mathf.Sign(userInputX);
        //movementDirY = Mathf.Sign(userInputY);
        
        // Move the game object
        if (userInputX != 0 || userInputY !=0){
            Vector3 playerMove = new Vector3(userInputX*speed*Time.deltaTime, userInputY*speed*Time.deltaTime, 0);
            transform.position = transform.position+playerMove;
        }
        
    }
}
