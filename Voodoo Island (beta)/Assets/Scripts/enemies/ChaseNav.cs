using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseNav : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject target;
    private NavMeshAgent agent;
    private bool stop;
    Animator anim;
    public bool mouth = false;
    private Melee melee;
    private ParticleSystem particle;
    public int health = 3;
    public AudioSource chomp;
    public AudioSource slime;
    public AudioSource growl;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        anim = GetComponent<Animator>();
        melee = GetComponentInChildren<Melee>();
        particle = GetComponentInChildren<ParticleSystem>();
        //particle.Pause();

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
            slime.Play();
            Navigate.DebugDrawPath(agent.path.corners);
        }
        if (mouth)
        {
            //Debug.Log(agent.velocity.x);

            if (melee.currentRange())
            {
                anim.SetTrigger("mouth eat");
                chomp.Play();
            }

            else if (agent.velocity.x < 0)
            {
                anim.SetTrigger("mouth left");
                chomp.Play();

            }
            else if (agent.velocity.x > 0)
            {
                anim.SetTrigger("mouth right");
                chomp.Play();
            }

            else
            {
                anim.SetTrigger("mouth idle");
            }
        }
    }

        
    
    void OnTriggerEnter2D(Collider2D other)
    {
        //Bullet b = other.GetComponent<Bullet>();
        if (other.tag == "Bullet")
        {
            particle.Play();
            ParticleSystem.EmissionModule em = particle.emission;
            em.enabled = true;
            growl.Play();
            health--;
            Destroy(other.gameObject);
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

}
