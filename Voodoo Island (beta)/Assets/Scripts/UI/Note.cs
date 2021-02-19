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
    //public AudioSource rustle;
    //public AudioSource lightning;
    public Sprite img;
    public static bool evilStatue;

    private AudioSource[] audios;


    IEnumerator SoundDelay()
    {
        //yield on a new YieldInstruction that waits for 3 seconds.
        yield return new WaitForSeconds(3);
        GetComponentInParent<Statue>().spooky();
        audios[2].Play();
    }

    // Start is called before the first frame update
    void Start()
    {
        InteractKey.SetActive(false);
        evilStatue = false;
        audios = GetComponents<AudioSource>();
    }

    void OnTriggerStay2D(Collider2D other)
    {
        // Check the tag of the object the player
        // has collided with
        
        objname = gameObject.name;
        //Debug.Log(other.tag);
        if (other.tag == "Player")
        {
            InteractKey.SetActive(true); // false to hide, true to show

            if (Input.GetKey(KeyCode.E))
            {
                reading = true;
                if(transform.parent != null && transform.parent.tag == "Door")
                {
                    audios[1].Play();
                }
                else
                {
                    audios[0].Play();
                }
                
                InteractKey.SetActive(false);
                headShot.sprite = img;
                if (objname == "NoExit")
                {
                    textObject.text = "I'd have to be crazy to leave now. My family needs me.";
                    header.text = "Thoughts";
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
                else if (objname == "DraftPlans")
                {
                    textObject.text = "This looks like a lot of plans. Plans to… to start selling off parts of the island to other logging companies? Dad? Mum? Why would you do this?";
                    header.text = "Draft Plans";
                }
                else if (objname == "WitchRambling")
                {
                    textObject.text = "[This is mostly in a language you don't understand. But there appears to be a patchy bit in English...] \nWhen the three needles are placed within the doll … no longer ... ?";
                    header.text = "Scribblings of the Witch";
                }
                else if (objname == "LockedDoor1")
                {
                    textObject.text = "Damn it. The door's jammed. … Feels like something's holding it shut from the other side.";
                    header.text = "Locked Door";
                }
                else if (objname == "LockedDoor2")
                {
                    textObject.text = "Damn it. The room ahead is blocked. Looks like the roof caved in…";
                    header.text = "Locked Door";
                }
                else if (objname == "LockedDoor3")
                {
                    textObject.text = "This door is completely jammed. No matter how hard I try, I can't open it.";
                    header.text = "Locked Door";
                }
                else if (objname == "Toilet")
                {
                    textObject.text = "Ugh, you want me to stick my hand in that? No way pal, not for all the ammo in the world. My name's not James, that's for sure.";
                    header.text = "Toilet";
                }
                else if (objname == "RegularStatueNote")
                {
                    textObject.text = "This site is dedicated to Maria Farthing, for her dedication to nature\nand continued preservation of the island we call home.";
                    header.text = "Inscription at foot of the statue";
                    evilStatue = true;
                    StartCoroutine(SoundDelay());
                }
                else if (objname == "StatueNote")
                {
                    textObject.text = "COLLECT THE THREE NEEDLES. SURVIVE. KILL THE WITCH. \n...[The Witch?]";
                    header.text = "Ragged carving at foot of statue";
                }
                else if (objname == "ShoppingList")
                {
                    textObject.text = "Dear George, I hate to be a bother, but we're short on fresh vegetables. When you place your next order, would you please be able to get some … [the letter is otherwise illegible]";
                    header.text = "Shopping Order";
                } 
                else if (objname == "HystericalLetter")
                {
                    textObject.text = "The words 'I WON'T LET IT HAPPEN' are scrawled in messy handwriting down the page.\nWhoever wrote this must surely be insane.";
                    header.text = "Strange Note";
                }
                else if (objname == "VoodooBook")
                {
                    textObject.text = "Needles within a doll can't be removed without the destruction of its sister needle, while also holding the doll. This linking allows for the practitioner to keep the curse going, even if the target finds the doll.";
                    header.text = "Book on Voodoo";
                }
                else if (objname == "VoodooNote")
                {
                    textObject.text = "A voodoo doll is used to cripple the target. Three needles are placed within the doll replica of the target. This then allows the practitioner to hurt the target remotely. Needles can only be removed by...";
                    header.text = "Extract from a book";
                }
                else if (objname == "LockedNursery")
                {
                    textObject.text = "The old nursery is locked up tight. To be perfectly honest, I'm not sure I'd like to see what's in there now. I can hear breathing sounds from inside.";
                    header.text = "Locked Nursery Door";
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
        if (Input.anyKeyDown && reading == true)
        {
            reading = false;
            InteractKey.SetActive(true);
        }
    }
}
