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
    


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        anim = GetComponent<Animator>();
        melee = GetComponentInChildren<Melee>();
        particle = GetComponentInChildren<ParticleSystem>();
        particle.Pause();

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
        if (mouth)
        {
            //Debug.Log(agent.velocity.x);

            if (melee.inRange)
            {
                anim.SetTrigger("mouth eat");
            }

            else if (agent.velocity.x < 0)
            {
                anim.SetTrigger("mouth left");
            }
            else if (agent.velocity.x > 0)
            {
                anim.SetTrigger("mouth right");
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
            Destroy(other.gameObject);  
            Destroy(gameObject);
        }
    }

}
