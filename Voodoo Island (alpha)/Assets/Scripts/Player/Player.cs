using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{

    // Reference to animator component
    Animator anim;

    //set the starting ammo
    public int ammo = 6;

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
    private string colliderTagName;

    private AmmoPickup ammoPickup;


    void OnTriggerEnter2D(Collider2D other)
    {
        //Check if the player is on a key and allow the player to pick up a key
        if (other.tag == "Key" || other.tag == "BulletPickUp")
        {
            pickupItem = other.gameObject;
            canPickUp = true;
            colliderTagName = other.tag;

            if(other.tag == "BulletPickUp")
            {
                ammoPickup = other.gameObject.GetComponent<AmmoPickup>();
            }

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

        // Initialise the reference to the Animator component
        anim = GetComponent<Animator>();
    }

    // Update is called once per frames
    void Update()
    {
      
        //calcuate the players speed based on delta time 
        float var = Time.deltaTime * speed;

        //get movement input
        float GetX = Input.GetAxis("Horizontal");
        float GetY = Input.GetAxis("Vertical");

        //Animation code
        
        if(GetX < 0)
        {
            anim.SetTrigger("Left");   
        }
        else if (GetX > 0)
        {
            anim.SetTrigger("Right");
        }
        else if(GetY != 0)
        {
            anim.SetTrigger("Forward");
        }
        else
        {
            anim.SetTrigger("Idle");
        }


        Vector3 movement = new Vector3(GetX*speed+ 0.0005f,GetY*speed, 0);
        //move the players based on there speed
        GetComponent<NavMeshAgent>().velocity = movement;

        if (canPickUp && Input.GetKeyDown(KeyCode.E))
        {
            if(colliderTagName == "Key")
            {
                hasKey = true;
                Destroy(pickupItem);
            }
            if(colliderTagName == "BulletPickUp")
            
            {
                ammo += ammoPickup.value;
                if (ammoPickup.finite)
                {
                    Destroy(pickupItem);
                }
                
            }
            canPickUp = false;
            
        }

        
        
    }
}
