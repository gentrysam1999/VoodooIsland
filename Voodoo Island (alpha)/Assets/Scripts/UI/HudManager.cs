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

    public GameObject Gameover;

    public Button Continue;
    public Button Exit;

    // the text box that contains how much ammo you have left
    public static Text ammoText;

    // the slider that represents the amount of health you have
    public Slider hudHealth;

    //The panel that contains the health bar. We need this to hide the slider
    public GameObject hPanel;

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

        Gameover = GameObject.Find("GameOver");
        Button btn = Continue.GetComponent<Button>();
        Button btn2 = Exit.GetComponent<Button>();

        Gameover.SetActive(false);

        inventoryGrid.SetActive(true);

        hudHealth.value = pl.health;

        //  GameObject[] objArray = GameObject.FindGameObjectsWithTag("gameoverTrigger");
        //  gameoverInfoProvider = objArray[0].GetComponent<Remover>();

        // health = healthInfoProvider.health;

        // Initialise the reference to the script object, which is a
        // component of the pause menu panel game object
        pauseMenu = pauseMenuPanel.GetComponent<PauseMenuManager>();
        pauseMenu.Hide();
    }

    void ExitGame()
    {
        Application.Quit();
    }

    void ContinueGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
        ammoText.text = s.bulletsInClip.ToString() + "/" + pl.ammo.ToString()  ;
        hudHealth.value = pl.health;

        if (pl.health <= 0)
        {
            Gameover.SetActive(true);

            Continue.onClick.AddListener(ContinueGame);
            Exit.onClick.AddListener(ExitGame);
        }

        }
    }