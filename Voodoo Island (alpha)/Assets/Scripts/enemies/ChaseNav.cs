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


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.transform.position);
        Navigate.DebugDrawPath(agent.path.corners);
        //Debug.Log(agent.velocity.ToString());
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        //Bullet b = other.GetComponent<Bullet>();
        if (other.tag == "Bullet")
        {
            Destroy(gameObject);
        }
    }

}
