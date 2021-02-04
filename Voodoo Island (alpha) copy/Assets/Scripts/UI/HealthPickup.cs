using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject InteractKey;

    private void Start()
    {
        InteractKey.SetActive(false);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        // Check the tag of the object the player
        // has collided with
        if (other.tag == "Player")
        {
            InteractKey.SetActive(true); // false to hide, true to show
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            InteractKey.SetActive(false);
        }
    }
}