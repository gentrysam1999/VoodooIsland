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
    private bool mouth;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        EnemySight enemySight = GetComponent<EnemySight>();
        if (enemySight.isActive())
        {
            agent.SetDestination(target.transform.position);
            Navigate.DebugDrawPath(agent.path.corners);
        }
        if (agent.velocity.x < 0)
        {
            anim.SetTrigger("mouth_Left");
        }
        else if (agent.velocity.x > 0)
        {
            anim.SetTrigger("mouth_Right");
        }
       
        }
        else
        {
            anim.SetTrigger("Mouth Idle");
        }

        Debug.Log(agent.velocity.ToString());
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        //Bullet b = other.GetComponent<Bullet>();
        if (other.tag == "Bullet")
        {
            Destroy(other.gameObject);  
            Destroy(gameObject);
        }
    }

}
