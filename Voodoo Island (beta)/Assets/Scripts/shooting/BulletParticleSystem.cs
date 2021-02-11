using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletParticleSystem : MonoBehaviour
{
    private ParticleSystem particle;
    // Start is called before the first frame update
    void Start()
    {
        particle = GetComponentInChildren<ParticleSystem>();
        particle.Play();
        ParticleSystem.EmissionModule em = particle.emission;
        em.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
