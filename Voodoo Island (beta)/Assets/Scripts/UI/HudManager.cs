﻿using UnityEngine;
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

    // the text box that contains how much ammo you have left
    public static Text ammoText;

    // the slider that represents the amount of health you have
    public Slider hudHealth;

    //The panel that contains the health bar. We need this to hide the slider
    public GameObject hPanel;

    public GameObject GameOver;
    public Button ContinueButton;
    public Button QuitButton;

    private Button btnC;
    private Button btnQ;

    //The GameObject that represents the player so we can access ammo and health values for HUD
    public GameObject p;
    // The Player object used alongside p
    private Player pl;

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

        hPanel = GameObject.Find("hPanel");

        pl = p.GetComponent<Player>();

        textbox = GameObject.Find("Textbox");
        textbox.SetActive(false);

        inventoryGrid.SetActive(true);

        GameOver = GameObject.Find("GameOver");
        GameOver.SetActive(false);

        Button btnC = ContinueButton.GetComponent<Button>();
        Button btnQ = ContinueButton.GetComponent<Button>();

        btnC.onClick.AddListener(ContinueGame);
        btnQ.onClick.AddListener(QuitGame);

        hudHealth.value = pl.health;

        // Initialise the reference to the script object, which is a
        // component of the pause menu panel game object
        pauseMenu = pauseMenuPanel.GetComponent<PauseMenuManager>();
        pauseMenu.Hide();
    }

    void QuitGame()
    {
        Application.Quit();
    }

    void ContinueGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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

        Shooting s = pl.GetComponentInChildren<Shooting>();
        if (s.reloading)
        {
            ammoText.text = "load\n-ing";
        }
        else
        {
            ammoText.text = s.bulletsInClip.ToString() + "/" + pl.ammo.ToString();
        }
        hudHealth.value = pl.health;

        if (pl.health <= 0)
        {
            GameOver.SetActive(true);
            hPanel.SetActive(false);
            inventoryGrid.SetActive(false);
            pauseMenuPanel.SetActive(false);
        }
        }
    }