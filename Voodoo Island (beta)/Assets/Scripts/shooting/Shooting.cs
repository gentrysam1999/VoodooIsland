﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float fireCooldownTime;
    public Transform player;
    public float bulletForce = 20f;
    public bool autoShoot;
    public ParticleSystem particles;
    private float fireCoolDownTimeLeft =0;

    public float reloadTime = 0;
    public int clipSize = 0;
    public int bulletsInClip = 0;

    public bool reloading = false;
    private float reloadTimeLeft = 0;
    // Update is called once per frame

    void Start()
    {
        particles.Pause();
    }



    void Update()
    {
        if (fireCoolDownTimeLeft > 0)
        {
            fireCoolDownTimeLeft -= Time.fixedDeltaTime;
        }
        if (!autoShoot)
        {

            
            Player p = gameObject.GetComponentInParent<Player>();
            if (reloading)
            {

                reloadTimeLeft -= Time.fixedDeltaTime;
                //Debug.Log(reloadTimeLeft);
                if (reloadTimeLeft <= 0)
                {
                  
                    bulletsInClip = clipSize;
                    reloading = false;

                }
            }
            if ((Input.GetKeyDown(KeyCode.R) || bulletsInClip == 0) && reloading == false && bulletsInClip< clipSize)
            {
                if (bulletsInClip != clipSize)
                {
                    reloading = true;
                    reloadTimeLeft = reloadTime;
                }
            }



            if (Input.GetButtonDown("Fire1") && fireCoolDownTimeLeft <= 0 && !autoShoot && !reloading)
            {
                //Debug.Log(reloadTimeLeft);
                if (reloadTimeLeft <= 0)

                {

                    if (bulletsInClip > 0)
                    {
                        bulletsInClip--;
                        shoot();
                        p.gunShot.Play();
                    }

                }


            }
        }
        else if (autoShoot && fireCoolDownTimeLeft <= 0)
        {
            EnemySight enemySight = GetComponent<EnemySight>();
            if (enemySight.isActive())
            {
                shoot();
            }

        }
    }

    void shoot()
    {
        if (Time.timeScale != 0)
        {
            if (particles != null)
            {
                particles.Play();
                ParticleSystem.EmissionModule em = particles.emission;
                em.enabled = true;
            }
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(-(firePoint.up) * bulletForce, ForceMode2D.Impulse);
            fireCoolDownTimeLeft = fireCooldownTime;
        }
    }
}
