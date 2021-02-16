using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float fireCooldownTime;
    public Transform player;

    public float bulletForce = 20f;
    
    protected GameObject currentBullet;
    protected float fireCoolDownTimeLeft =0;

    protected void Start()
    {
        currentBullet = bulletPrefab;
    }

    

    
    public AudioSource gunShot;


    protected void Update()
    {
        if (fireCoolDownTimeLeft > 0)
        {
            fireCoolDownTimeLeft -= Time.fixedDeltaTime;
        }
    }

    protected void shoot()
    {
        if (Time.timeScale != 0)
        {
 
            GameObject bullet = Instantiate(currentBullet, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(-(firePoint.up) * bulletForce, ForceMode2D.Impulse);
            fireCoolDownTimeLeft = fireCooldownTime;
        }
    }

    
}
