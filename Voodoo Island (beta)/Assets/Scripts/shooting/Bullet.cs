using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //public GameObject hitEffect;
    void OnTriggerEnter2D(Collider2D other)
    {
        //Check if key
        if (other.tag == "Wall")
        {
            Debug.Log("hit");
            //GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            //Destroy(effect, 5f);
            Destroy(gameObject);
            //Debug.Log("destroy");
        }

        if (other.tag == "Door")
        {
            Debug.Log("hit");
            Destroy(gameObject);
        }


    }
}
