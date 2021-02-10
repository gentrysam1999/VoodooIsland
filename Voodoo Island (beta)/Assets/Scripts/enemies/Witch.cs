using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Witch : MonoBehaviour
{

    public int health = 20;

    public GameObject locations;

    public Transform player;

    //The witch travel too her children
    private Transform[] places;

    //Target location for the witch
    private Transform target;

    private NavMeshAgent agent;

    private int lastLocation = 1;

    private ParticleSystem particle;


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
        Vector3 pos = transform.position;
        pos.z = 0;
        transform.position = pos;
        EnemySight enemySight = GetComponent<EnemySight>();
        if (enemySight.isActive())
        {
            agent.SetDestination(target.transform.position);
            Navigate.DebugDrawPath(agent.path.corners);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bullet")
        {

            //Particle system
            particle = GetComponentInChildren<ParticleSystem>();
            particle.Play();
            ParticleSystem.EmissionModule em = GetComponentInChildren<ParticleSystem>().emission;
            em.enabled = true;


            Destroy(other.gameObject);
            health --;
            if(health <= 0)
            {
                Destroy(gameObject);
            }
        }
        if (other.tag == "WitchTarget")
        {
            //choose a new random target location for the witch to go too
            int newLocation = Random.Range(1, places.Length);

            // check it is not the current location
            while (newLocation == lastLocation)
            {
                newLocation = Random.Range(1, places.Length);
            }
            

            //move to the nextLocation;
            target = places[newLocation];
            lastLocation = newLocation;
        }
    }
}
