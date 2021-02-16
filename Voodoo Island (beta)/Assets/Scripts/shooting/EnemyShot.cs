using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this class requires a child with the point to player script to work. the player is passed in here
// so prefabs can be configered in the same place
public class EnemyShot : Shooting
{
        
    
    
    
    // Start is called before tshe first frame update


    // Update is called once per frame
    new void Update()
    {
        base.Update();
        if (fireCoolDownTimeLeft <= 0)
        {
            EnemySight enemySight = GetComponent<EnemySight>();
            if (enemySight.isActive())
            {
                shoot();
                //w.Shot.Play();
            }
        }
    }

    new void shoot()
    {
        base.shoot();
    }
    
}
