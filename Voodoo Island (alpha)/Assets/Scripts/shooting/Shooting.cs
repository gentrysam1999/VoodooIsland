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
    public Transform target;

    private float fireCoolDownTimeLeft =0;

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
                shoot();
            }
        }
        else if(autoShoot && fireCoolDownTimeLeft <= 0)
        {
            shoot();
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
