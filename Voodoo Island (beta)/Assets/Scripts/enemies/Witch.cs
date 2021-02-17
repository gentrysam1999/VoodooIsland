using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Witch : MonoBehaviour
{


    public float attackLength = 5;

    public int health = 40;

    public Slider witchHealthSlider;

    public GameObject locations;

    public GameObject location2;

    //public Transform player;

    //The witch travel too her children
    private Transform[] places;
    private Transform[] places2;

    //Target location for the witch
    private Transform target;

    private NavMeshAgent agent;

    private int lastLocation = 1;

    private ParticleSystem particle;

    public AudioSource witch;

    public AudioSource Shot;

    // Start is called before the first frame update
    void Start()
    {
        
        


        
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        places = locations.GetComponentsInChildren<Transform>();
        places2 = location2.GetComponentsInChildren<Transform>();

        target = places[lastLocation];
        witchHealthSlider.value = health;



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
        witchHealthSlider.value = health;
        Debug.Log(health);
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
            witch.Play();

            if(health <= 0)
            {
                Destroy(gameObject);
                SceneManager.LoadScene("Finish");

            }
        }
        if (other.tag == "WitchTarget")
        {
            //choose a new random target location for the witch to go too

            if (health < 20)
            {
                int newLocation2 = Random.Range(1, places2.Length);

                // check it is not the current location
                while (newLocation2 == lastLocation)
                {
                    newLocation2 = Random.Range(1, places2.Length);
                }


                //move to the nextLocation;
                target = places2[newLocation2];
                lastLocation = newLocation2;
            }
            else
            {
                int newLocation = Random.Range(1, places.Length);

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
}
