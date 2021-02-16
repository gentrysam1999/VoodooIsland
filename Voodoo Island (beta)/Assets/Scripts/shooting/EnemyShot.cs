using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitchShooting : Shooting
{
    public Transform player;
    private Witch w;
    public ParticleSystem particles;
    // Start is called before the first frame update


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
                w.Shot.Play();
            }
        }
    }
    void Start()
    {
        particles.Pause();
        w = gameObject.GetComponentInParent<Witch>();
    }
    new void shoot()
    {
        if (Time.timeScale != 0)
        {
            if (particles != null)
            {
                particles.Play();
                ParticleSystem.EmissionModule em = particles.emission;
                em.enabled = true;
            }
        }
        base.shoot();
    }
}
