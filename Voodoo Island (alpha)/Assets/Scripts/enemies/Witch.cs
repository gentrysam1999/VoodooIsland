using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Witch : MonoBehaviour
{

    public int health = 20;

    public GameObject locations;

    //The witch travel too her children
    private Transform[] places;

    //Target location for the witch
    private Transform target;

    private NavMeshAgent agent;

    private int lastLocation = 1;

    
    // Start is called before the first frame update
    void Start()
    {
        
        places = locations.GetComponentsInChildren<Transform>();

        target = places[lastLocation];

        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.transform.position);
        Navigate.DebugDrawPath(agent.path.corners);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bullet")
        {
            health --;
        }
        if (other.tag == "WitchTarget")
        {
            //choose a new random target location for the witch to go too
            int newLocation = Random.Range(0, places.Length);

            // check it is not the current location
            while (newLocation == lastLocation)
            {
                newLocation = Random.Range(0, places.Length);
            }
            

            //move to the nextLocation;
            target = places[newLocation];
            lastLocation = newLocation;
        }
    }
}
