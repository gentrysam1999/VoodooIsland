﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HudManager : MonoBehaviour
{
    // the GameObject textbox
    public GameObject textbox;
    // the text element found in textbox
    public static Text note;

    // References to UI elements on the canvas
    public GameObject Health = null;

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

        inventoryGrid = GameObject.Find("inventorygrid");

        textbox = GameObject.Find("Textbox");
        textbox.SetActive(false);

        Health = GameObject.Find("Health");

        inventoryGrid.SetActive(true);

        // GameObject[] objArray = GameObject.FindGameObjectsWithTag("gameoverTrigger");
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
            Health.SetActive(false);
            Time.timeScale = 0;
        } else if (Note.reading == false)
        {
            textbox.SetActive(false);
            inventoryGrid.SetActive(true);
            Health.SetActive(true);
            Time.timeScale = 1f;
        }
        if (Input.GetKey(KeyCode.Escape) && Note.reading == false)
        {
            // If user presses ESC, show the pause menu in pause mode
            pauseMenu.ShowPause();
        }
    }
}