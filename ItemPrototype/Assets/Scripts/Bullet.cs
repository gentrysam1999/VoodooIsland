using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Bullet : MonoBehaviour
{

    private Vector3 target;
    private float speed;
    private NavMeshAgent agent;
    float index = 0;
    float max = 90;
    


    //called when the bullet is shot
    public void created()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    // Update is called once per frame
    void Update()
    {
        if(index < max)
        {
            transform.Translate(new Vector3((target.x /max), (target.y / max), 0));
            index++;
        }
        else
        {
            Destroy(gameObject);

        }

    }
}
