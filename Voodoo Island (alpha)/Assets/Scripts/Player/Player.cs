using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{

    //set the starting ammo
    public int ammo = 0;

    //set the players speed. 
    public float speed = 10;

    //set this too true if the player has key in there inventory
    private bool hasKey = false;

    //set to true if the player is on a key 
    private bool canPickUp = false;

    //a referance to the item the player is standing on
    private UnityEngine.Object pickupItem;

    //a referance to the navmeshagent compoent to controll the players movement.
    private NavMeshAgent agent;

    //pickUpName
    private string name;

    void OnTriggerEnter2D(Collider2D other)
    {
        //Check if the player is on a key and allow the player to pick up a key
        if (other.tag == "Key" || other.tag == "BulletPickUp")
        {
            pickupItem = other.gameObject;
            canPickUp = true;
            name = other.tag;

        }
      
    }




    void OnTriggerExit2D(Collider2D other)
    {
        //if the player is no longer on a key they can't pick it up
        if(other.tag == "Key" || other.tag == "BulletPickUp")
        {
            canPickUp = false;
        }
    }

    
    void OnCollisionEnter2D(Collision2D other)
    {
        //if the player runs into a door and has a key remove the door
        if(other.gameObject.tag == "Door" && hasKey)
        {
            hasKey = false;
            Destroy(other.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //do not allow the agent compoent to rotate the player
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Update is called once per frames
    void Update()
    {
      
        //calcuate the players speed based on delta time 
        float var = Time.deltaTime * speed;

        //get movement input
        float GetX = Input.GetAxis("Horizontal");
        float GetY = Input.GetAxis("Vertical");


        Vector3 movement = new Vector3(GetX*speed+ 0.0005f,GetY*speed, 0);
        //move the players based on there speed
        GetComponent<NavMeshAgent>().velocity = movement;

        if (canPickUp && Input.GetKeyDown(KeyCode.E))
        {
            if(name == "Key")
            {
                hasKey = true;
                Destroy(pickupItem);
            }
            if(name == "BulletPickUp")
            {
                //ammo += pickupItem.GetComponent<AmmoPickup>().value;
               // if (pickupItem.GetComponent<AmmoPickup>().finite)
               // {
                    Destroy(pickupItem);
               // }
                
            }
            canPickUp = false;
            
        }

        
        
    }
}
