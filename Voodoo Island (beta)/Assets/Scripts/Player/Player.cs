using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{

    // Reference to animator component
    Animator anim;


    public int ammoMax = 24;

    public int health;

    //set the starting ammo
    public int ammo;

    //set the players speed. 
    public float speed = 25; // was originally 30, debuffed until later

    //set this to true if the player has key in their inventory
    public bool hasKey = false;

    // set to true if the player has the voodoo doll in their inventory
    public bool hasDoll = false;

    //set to true if the player is on a key 
    private bool canPickUp = false;

    //a referance to the item the player is standing on
    private UnityEngine.Object pickupItem;

    //a referance to the navmeshagent component to control the players movement.
    private NavMeshAgent agent;

    // the sound of the gunshot whenever the player fires
    public AudioSource gunShot;

    //Sound of lock unlocking
    public AudioSource Lock;

    //Pick Up Sound
    public AudioSource obtained;

    public int needle = 0;

    //pickUpName
    private string colliderTagName;

    private AmmoPickup ammoPickup;


    public void takeDamage(int amount)
    {
        health -= amount;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Check if the player is on a key and allow the player to pick up a key
        if (other.tag == "Key" || other.tag == "VoodooPickUp" || other.tag == "HealthPickUp" || other.tag == "Needle")
        {
            pickupItem = other.gameObject;
            canPickUp = true;
            colliderTagName = other.tag;

            if(other.tag == "BulletPickUp")
            {
                ammoPickup = other.gameObject.GetComponent<AmmoPickup>();
            }
        }
        else if(other.tag  == "WitchAttack"){
            Destroy(other.gameObject);
            takeDamage(1);
        }
        else if(other.tag == "MeleeEnemy")
        {
            Melee m = other.gameObject.GetComponent<Melee>();
            m.isInRange();
        }
        //if the player runs into a door and has a key remove the door
        else if (other.tag == "Lock" && hasKey)
        {
            hasKey = false;
            Lock.Play();
            Destroy(other.gameObject);
        }
    }


    void OnTriggerExit2D(Collider2D other)
    {
        //if the player is no longer on a key they can't pick it up
        if(other.tag == "Key" || other.tag == "VoodooPickUp" || other.tag == "HealthPickUp")
        {
            canPickUp = false;
        }
        else if(other.tag== "MeleeEnemy")
        {
            Melee m = other.gameObject.GetComponent<Melee>();
            m.leftRange();
        }
    }

    
    /*void OnCollisionEnter2D(Collision2D other)
    {
        //if the player runs into a door and has a key remove the door
        if(other.gameObject.tag == "Lock" && hasKey)
        {
            hasKey = false;
            Destroy(other.gameObject);
        }
    }*/

    private void OnTriggerStay2D(Collider2D other)
    {
        //Check if the player is on a key and allow the player to pick up a key
        if ( other.tag == "BulletPickUp")
        {
            pickupItem = other.gameObject;
            canPickUp = true;
            colliderTagName = other.tag;

            if (other.tag == "BulletPickUp")
            {
                ammoPickup = other.gameObject.GetComponent<AmmoPickup>();
            }

        }
    }

    // This method is used for the upgrades that are acquired to counter the debuffs from the Witch
    void NeedleUp()
    {
        if (needle == 1) // first buff
        {
            speed = 30;
        } 
        else if(needle == 2) // second buff
        {
            health = 7;
        } 
        else if (needle == 3) // third and final buff
        {
            // not sure what the final buff should be
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
        ammo = GlobalControl.Instance.Ammo;
        health = GlobalControl.Instance.HP;
        

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
        if (Time.timeScale != 0)
        {
            if (health <= 0)
            {
                Destroy(gameObject);
            }

            //calcuate the players speed based on delta time 
            float var = Time.deltaTime * speed;

            //get movement input
            float GetX = Input.GetAxis("Horizontal");
            float GetY = Input.GetAxis("Vertical");

            //Animation code
            if (GetX < 0)
            {
                anim.SetTrigger("Left");
            }
            else if (GetX > 0)
            {
                anim.SetTrigger("Right");
            }
            else if (GetY != 0)
            {
                anim.SetTrigger("Forward");
            }
            else
            {
                anim.SetTrigger("Idle");
            }


            Vector3 movement = new Vector3(GetX * speed + 0.005f, GetY * speed, 0);
            //move the players based on there speed
            GetComponent<NavMeshAgent>().velocity = movement;

            if (canPickUp && Input.GetKeyDown(KeyCode.E))
            {
                if (colliderTagName == "Key")
                {
                    hasKey = true;
                    obtained.Play();
                    Destroy(pickupItem);
                }
                if (colliderTagName == "VoodooPickUp")

                {
                  Destroy(pickupItem);
                  obtained.Play();
                  hasDoll = true;

                }
                if (colliderTagName == "HealthPickUp")
                {
                    health++;
                    obtained.Play();
                    Destroy(pickupItem);
                }
                if(colliderTagName == "Needle")
                {
                    needle++;
                    Destroy(pickupItem);
                    obtained.Play();
                    NeedleUp();
                }
            }

        }



        
        
    }


    public void SavePlayer()
    {
        GlobalControl.Instance.Ammo = ammo;
        GlobalControl.Instance.HP = health;
    }
}
