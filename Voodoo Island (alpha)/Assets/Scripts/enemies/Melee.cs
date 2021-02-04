using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Melee : MonoBehaviour
{

    public int damage = 1;
    public float fireCooldownTime = 10;
    private float speed;

    public bool inRange = false;
    private float fireCoolDownTimeLeft = 0;
    private NavMeshAgent agent;
    private Player player;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        speed = agent.speed;

        ChaseNav c = GetComponent<ChaseNav>();
        player = c.target.GetComponent<Player>();
    }

    void Update()
    {
        if(fireCooldownTime <= 0)
        {
            if (inRange)
            {
                player.takeDamage(1);
                fireCoolDownTimeLeft = fireCooldownTime;
                agent.speed = 0;
            }
            else
            {
                agent.speed = speed;
            }
        }
        if (fireCoolDownTimeLeft > 0)
        {
            fireCoolDownTimeLeft -= Time.fixedDeltaTime;
        }   

    }

}
