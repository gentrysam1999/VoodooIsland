using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float fireCooldownTimeLeft;
    public float bulletForce = 20f;
    public bool autoShoot;


    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")&& fireCooldownTimeLeft <=0&&!autoShoot){
            Player p = gameObject.GetComponentInParent<Player>();
            if (p.ammo > 0)
            {
                p.ammo--;
                Shoot();
            }
        }
        else if(autoShoot && fireCooldownTimeLeft <= 0)
        {
            Shoot();
        }
    }

    void Shoot(){
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(-(firePoint.up) * bulletForce, ForceMode2D.Impulse);
    }
}
