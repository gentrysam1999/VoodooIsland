using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Battery : MonoBehaviour
{
    GameObject InteractKey;
    GameObject Btery;

    private void Start()
    {
        InteractKey = GameObject.Find("InteractKey");
        Btery = GameObject.Find("Battery");
        InteractKey.SetActive(false);
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
                Btery.SetActive(false);
            }

        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // Check the tag of the object the player
        // has ceased to collide with
        if (other.tag == "Player")
        {
            // If collided with the left wall, set
            // the left wall flag to true
            InteractKey.SetActive(false);
        }
    }
}
