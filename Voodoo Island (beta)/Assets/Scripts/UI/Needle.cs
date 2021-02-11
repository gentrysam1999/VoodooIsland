using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Needle : MonoBehaviour
{
    public GameObject InteractKey;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerStay2D(Collider2D other)
        {
            // Check the tag of the object the player
            // has collided with
            if (other.tag == "Player")
            {
                InteractKey.SetActive(true); // false to hide, true to show

            if (Input.GetKey(KeyCode.E))
            {
                InteractKey.SetActive(false); // false to hide, true to show
            }
            }
        }

    void OnTriggerLeave2D(Collider2D other)
    {
        // Check the tag of the object the player
        // has collided with
        if (other.tag == "Player")
        {
            InteractKey.SetActive(false); // false to hide, true to show
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
