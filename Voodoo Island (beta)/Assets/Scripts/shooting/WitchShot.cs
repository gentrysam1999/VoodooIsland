using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitchShot : Shooting
{

    public GameObject bulletPrefab2;
    public ParticleSystem particles;
    public float phaseLen = 5f;
    public float fireCoolDownMod = 2;

    private bool phase = false;
    private float phaseTimeLeft = 1;
    private Witch w;
    new void Start()
    {
        base.Start();
        particles.Pause();
        w = gameObject.GetComponent<Witch>();
    }

    //when too shoot phase 2 functionaility
    private void phaseTimer()
    {
        
            if (phaseTimeLeft > 0)
            {
                phaseTimeLeft -= Time.fixedDeltaTime;
            }
            else
            {
                phase = !phase;
                phaseTimeLeft = phaseLen;
                if (phase)
                {
                    currentBullet = bulletPrefab2;
                    fireCooldownTime = fireCooldownTime / fireCoolDownMod;
                }
                else
                {
                    fireCooldownTime *= fireCoolDownMod;
                    currentBullet = bulletPrefab;
            }
            }
        p1Shoot();
        
    }


    //check the phase 
    new void Update()
    {
        base.Update();

        if (w.health < 20)
        {
            phaseTimer();
        }
        else
        {
            p1Shoot();
            w.checkMovement();
        }

    }

    //paraticles and sounds
    new void shoot()
    {
        if (Time.timeScale != 0)
        {
            w.Shot.Play();
            if (particles != null)
            {
                particles.Play();
                ParticleSystem.EmissionModule em = particles.emission;
                em.enabled = true;
            }
        base.shoot();
        }
    }
    //when too shoot phase 1 functionaility
    private void p1Shoot()
    {
        if (fireCoolDownTimeLeft <= 0)
        {
            EnemySight enemySight = GetComponent<EnemySight>();
            if (enemySight.isActive())
            {
                shoot();
            }
        }
    }
}
