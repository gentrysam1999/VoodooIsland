using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShot : Shooting
{
    public float reloadTime = 0;
    public int clipSize = 0;
    public int bulletsFired = 0;

    private int bulletsInClip = 0;
    private Player pl;
    private bool reloading = false;
    private float reloadTimeLeft = 0;
    
    // Update is called once per frame
    new void Update()
    {
        base.Update();
        if (reloading)
        {

            reloadTimeLeft -= Time.fixedDeltaTime;
            
            if (reloadTimeLeft <= 0)
            {

                bulletsInClip = clipSize;
                reloading = false;

            }
        }
        if ((Input.GetKeyDown(KeyCode.R) || bulletsInClip == 0) && reloading == false && bulletsInClip < clipSize)
        {
            if (bulletsInClip != clipSize)
            {
                reloading = true;
                reloadTimeLeft = reloadTime;
            }
        }

        if (Input.GetButtonDown("Fire1") && fireCoolDownTimeLeft <= 0 && !reloading)
        {
            //Debug.Log(reloadTimeLeft);
            if (reloadTimeLeft <= 0)

            {

                if (bulletsInClip > 0)
                {
                    gunShot.Play();
                    bulletsInClip--;
                    GlobalControl.Instance.bulletsFired++;
                    shoot();
                }

            }

        }
    }


    public bool isReloading()
    {
        return reloading;
    }
    public int getBullets()
    {
        return bulletsInClip;
    }

}
