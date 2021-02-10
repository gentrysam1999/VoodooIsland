using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Shooting : MonoBehaviour 
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float fireCooldownTime;
    public ParticleSystem particles;
    
    public float bulletForce = 20f;
    public bool autoShoot;

    private float fireCoolDownTimeLeft =0;

    void Start(){
        particles.Pause();
    }
    // Update is called once per frame
    void Update()
    {

        if (fireCoolDownTimeLeft > 0)
        {
            fireCoolDownTimeLeft -= Time.fixedDeltaTime;
        }
        if (Input.GetButtonDown("Fire1")&& fireCoolDownTimeLeft  <= 0&&!autoShoot){
            Player p = gameObject.GetComponentInParent<Player>();
            if (p.ammo > 0)
            {
                p.ammo--;
                p.gunShot.Play();
                shoot();
            }
        }
        else if(autoShoot && fireCoolDownTimeLeft <= 0)
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
            if (particles!=null){
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
