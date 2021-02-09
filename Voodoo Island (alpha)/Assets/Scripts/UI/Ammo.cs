//using UnityEngine;
//using System.Collections;
//using UnityEngine.UI;
//using System;
//using UnityEngine.SceneManagement;

//public class Ammo : MonoBehaviour
//{
//    GameObject Interact;
//    GameObject ammo;
//    public Text ammoText;
//    public static int ammoCount;

//    private void Start()
//    {
//        Interact = GameObject.Find("InteractKey");
//        ammo = GameObject.Find("Ammo");
//        Interact.SetActive(false);
//    }

//    void OnTriggerStay2D(Collider2D other)
//    {
//        // Check the tag of the object the player
//        // has collided with
//        if (other.tag == "Player")
//        {
//            Interact.SetActive(true); // false to hide, true to show

//            if (Input.GetKey(KeyCode.E))
//            {
//                HudManager.AmmoUp();
//                ammo.SetActive(false);
//            }

//        }
//    }

//    void OnTriggerExit2D(Collider2D other)
//    {
//        // Check the tag of the object the player
//        // has ceased to collide with
//        if (other.tag == "Player")
//        {
//            // If collided with the left wall, set
//            // the left wall flag to true
//            Interact.SetActive(false);
//        }
//    }
//}
