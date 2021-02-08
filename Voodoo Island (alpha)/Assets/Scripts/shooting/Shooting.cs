using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float fireCooldownTime;
    
    public float bulletForce = 20f;
    public bool autoShoot;

    private float fireCoolDownTimeLeft =0;

    public float reloadTime = 0;
    public int clipSize = 0;
    private int bulletsInClip;

    private bool reloading = true;
    private float reloadTimeLeft = 0;
    // Update is called once per frame
    void Update()
    {
        
        if (fireCoolDownTimeLeft > 0)
        {
            fireCoolDownTimeLeft -= Time.fixedDeltaTime;
        }
        if (reloading)
        {
            reloadTimeLeft -= Time.fixedDeltaTime;
            if(reloadTimeLeft <= 0)
            {
                Player p = gameObject.GetComponentInParent<Player>();
                if(p.ammo > clipSize)
                {
                    bulletsInClip = clipSize;   
                }
                else
                {
                    bulletsInClip = p.ammo;
                }
                p.ammo -= bulletsInClip;
                reloading = false;
                reloadTimeLeft = reloadTime;
            }
        }
        if (Input.GetButtonDown("Fire1")&& fireCoolDownTimeLeft  <= 0&&!autoShoot){
            if (reloadTimeLeft <= 0)
            {

                if (bulletsInClip > 0)
                {
                    bulletsInClip--;
                    shoot();
                }
                else
                {
                    reloading = true;
                }
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
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(-(firePoint.up) * bulletForce, ForceMode2D.Impulse);
            fireCoolDownTimeLeft = fireCooldownTime;
        }
    }
}
