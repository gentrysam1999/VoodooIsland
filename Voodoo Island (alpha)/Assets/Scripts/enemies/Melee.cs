using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Melee : MonoBehaviour
{

    public int damage = 1;
    public float fireCooldownTime = 10;
    private float speed;

    private bool inRange = false;
    private float fireCoolDownTimeLeft = 0;
    private NavMeshAgent agent;
    private Player player;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponentInParent<NavMeshAgent>();
        speed = agent.speed;

        ChaseNav c = GetComponentInParent<ChaseNav>();
        player = c.target.GetComponent<Player>();
    }

    void Update()
    {
        if (fireCoolDownTimeLeft > 0)
        {
            fireCoolDownTimeLeft -= Time.fixedDeltaTime;
        }
        if (fireCoolDownTimeLeft <= 0)
        {
            Debug.Log(inRange);
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
         

    }

    public void isInRange()
    {
        inRange = true;
    }
    public void leftRange()
    {
        inRange = false;
    }
    

}
