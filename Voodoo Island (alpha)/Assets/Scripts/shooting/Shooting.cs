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
    public int bulletsInClip = 0;

    public bool reloading = false;
    private float reloadTimeLeft = 0;
    // Update is called once per frame


  
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
                Debug.Log(reloadTimeLeft);
                if (reloadTimeLeft <= 0)
                {
                    int rb = 0;
                    if (p.ammo > clipSize)
                    {
                        rb = 6;
                    }
                    else
                    {
                        rb = p.ammo;

                    }
                    rb -= bulletsInClip;
                    bulletsInClip += rb;
                    p.ammo -= rb;
                    reloading = false;

                }
            }
            if ((Input.GetKeyDown(KeyCode.R) || bulletsInClip == 0) && reloading == false && p.ammo > 0)
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
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(-(firePoint.up) * bulletForce, ForceMode2D.Impulse);
            fireCoolDownTimeLeft = fireCooldownTime;
        }
    }
}
