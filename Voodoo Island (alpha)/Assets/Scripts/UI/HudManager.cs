using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class HudManager : MonoBehaviour
{
    // the GameObject textbox
    public GameObject textbox;
    // the text element found in textbox
    public static Text note;

    public static Text ammoText;
    public static int ammoCount;

    public Slider hudHealth;

    public GameObject hPanel;

    public GameObject p;

    private Player pl;

    // References to UI elements on the canvas

    // Health value currently displayed
    float health;

    // Reference to UI panel that is our pause menu
    public GameObject pauseMenuPanel;
    // Reference to panel's script object 
    PauseMenuManager pauseMenu;
    //Reference to panel's inventory object
    public GameObject inventoryGrid;

    // Use this for initialization
    void Start()
    {
        note = GameObject.Find("Textbox").GetComponent<Text>();

        ammoText = GameObject.Find("ammonum").GetComponent<Text>();

        inventoryGrid = GameObject.Find("inventorygrid");

        hPanel = GameObject.Find("hPanel");

        pl = p.GetComponent<Player>();

        textbox = GameObject.Find("Textbox");
        textbox.SetActive(false);

        inventoryGrid.SetActive(true);

        //  GameObject[] objArray = GameObject.FindGameObjectsWithTag("gameoverTrigger");
        //  gameoverInfoProvider = objArray[0].GetComponent<Remover>();

        // Set the starting health value for display
        // health = healthInfoProvider.health;

        // Initialise the reference to the script object, which is a
        // component of the pause menu panel game object
        pauseMenu = pauseMenuPanel.GetComponent<PauseMenuManager>();
        pauseMenu.Hide();
    }

    // Update is called once per frame
    void Update()
    {
        if (Note.reading == true)
        {
            inventoryGrid.SetActive(false);
            textbox.SetActive(true);
            hPanel.SetActive(false);
            Time.timeScale = 0;
        }

        else if (Note.reading == false)

        {
            textbox.SetActive(false);
            inventoryGrid.SetActive(true);
            hPanel.SetActive(true);
            Time.timeScale = 1f;
        }

        if (Input.GetKey(KeyCode.Escape) && Note.reading == false)

        {
            // If user presses ESC, show the pause menu in pause mode
            pauseMenu.ShowPause();
        }

        ammoText.text = pl.ammo.ToString();

        if (Input.GetKey(KeyCode.Mouse0))
        {
            health = Mathf.MoveTowards(health, 100, 20 * Time.deltaTime);
            hudHealth.value = health;
            health--;
        }
    }
}