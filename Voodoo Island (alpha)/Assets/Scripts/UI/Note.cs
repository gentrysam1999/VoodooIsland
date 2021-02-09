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
