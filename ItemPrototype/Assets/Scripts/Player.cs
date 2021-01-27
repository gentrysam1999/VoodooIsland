using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{

    public float speed = 10;

    public float xOffSet = 3f;
    public float yOffSet = 3f;

    private bool hasKey = false;

    private bool canPickUp = false;

    private UnityEngine.Object key;
    private NavMeshAgent agent;


    public Transform shotPrefab;


    void OnTriggerEnter2D(Collider2D other)
    {
        //Check if key
        if (other.tag == "Key")
        {
            key = other.gameObject;
            canPickUp = true;

        }
    }




    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Key")
        {
            canPickUp = false;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {

        if(other.gameObject.tag == "Door" && hasKey)
        {
            hasKey = false;
            Destroy(other.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Update is called once per frames
    void Update()
    {
      

        float var = Time.deltaTime * speed;

        float GetX = Input.GetAxis("Horizontal");
        float GetY = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(GetX*speed+ 0.0005f,GetY*speed, 0);
        Vector3 moveDestination = transform.position + movement;
        GetComponent<NavMeshAgent>().velocity = movement;

        if (canPickUp && Input.GetKeyDown(KeyCode.E))
        {
            hasKey = true;
            canPickUp = false;
            Destroy(key);
        }

        
        
    }
}
