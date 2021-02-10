using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Note : MonoBehaviour
{
    public GameObject InteractKey;
    public static bool reading;
    string objname;
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
                if (objname == "Testnote")
                {
                    textObject.text = "There's something wrong with this place... it feels... unfinished somehow...";
                    header.text = "Testnote";
                }
                else if (objname == "ParentLetter")
                {
                    textObject.text = "Dear Jeff, dearest son, \nAwful things are happening here, things I cannot explain. But I fear that your sister can explain...";
                    header.text = "Letter from Parents";
                }
                else if (objname == "EmployeeLetter")
                {
                    textObject.text = "There is no cause for alarm. We will ensure that the ferry comes for everyone. Please stay calm, the situation is entirely under control.";
                    header.text = "Letter to Lumber Mill Employees";
                }
                else if (objname == "StrangeMessage")
                {
                    textObject.text = "The needle of man threads in and out of other's lives. You should not have returned to mine.\n[What a nutjob.]";
                    header.text = "Strange Message";
                }
                else if (objname == "ButlerMap")
                {
                    textObject.text = "[someone has scribbled all over a map of the complex, rendering it basically useless. \nIt appears to be the butler's escape plan - but you don't think anyone made it off the island.]";
                    header.text = "George's Escape Plan";
                }
                else if(objname == "DraftPlans")
                {
                    textObject.text = "This looks like a lot of plans. Plans to… to start selling off parts of the island to other logging companies? Dad? Mum? Why would you do this?";
                    header.text = "Draft Plans";
                }
                else if (objname == "WitchRambling")
                {
                    textObject.text = "[This is mostly in a language you don't understand. But there appears to be a patchy bit in English...] \nWhen the three needles are placed within the doll … no longer ... ?";
                    header.text = "Scribblings of the Witch";
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
