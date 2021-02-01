using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Note : MonoBehaviour
{
    public GameObject InteractKey;
    public static bool reading;
    public string objname;
    public Text textObject;
    public Text header;
    public Image headShot;
    public Sprite img;

    // Start is called before the first frame update
    void Start()
    {
        InteractKey = GameObject.Find("InteractKey");
        InteractKey.SetActive(false);
        objname = gameObject.name;
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
                reading = true;
                InteractKey.SetActive(false);
                headShot.sprite = img;
                if (objname == "Thought")
                {
                    textObject.text = "Wow, it's working...";
                    header.text = "Thoughts";
                }
                else if (objname == "Battery")
                {
                    textObject.text = "Trespassers will be prosecuted to the full extent of the law. \n[I don't remember this being here ten years ago.]";
                    header.text = "NO TRESSPASSERS sign";
                }
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            InteractKey.SetActive(false);
        }
    }

   // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.X) && reading == true)
        {
            reading = false;
            InteractKey.SetActive(true);
        }
    }
}
