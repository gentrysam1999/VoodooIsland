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

    public GameObject VoodooTextObject;
    public Text VoodooBuff;

    // the text box that contains how much ammo you have left
    public static Text ammoText;

    // the slider that represents the amount of health you have
    public Slider hudHealth;

    //The panel that contains the health bar. We need this to hide the slider
    public GameObject hPanel;
    public Slider healthSlider;

    public GameObject GameOver;

    //The GameObject that represents the player so we can access ammo and health values for HUD
    public GameObject p;
    // The Player object used alongside p
    private Player pl;

    public GameObject voodooDoll;
    public Image voodooDollImage;
    public Sprite oneNeedle;
    public Sprite twoNeedle;
    public Sprite noNeedle;

    public GameObject key;
    int deaths = GlobalControl.Instance.deaths;

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

        hudHealth.value = pl.health;

        voodooDoll.SetActive(false);

        // Initialise the reference to the script object, which is a
        // component of the pause menu panel game object
        pauseMenu = pauseMenuPanel.GetComponent<PauseMenuManager>();
        pauseMenu.Hide();
        key.SetActive(false);
    }

    public void ContinueGame()
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

        if (Input.GetKeyDown(KeyCode.Escape) && Note.reading == false)
        {
            // If user presses ESC, show the pause menu in pause mode
            pauseMenu.ShowPause();
        }
        if (pl.hasDoll == true)
        {
            voodooDoll.SetActive(true);
        }
        // the below code is to do with the needles and what happens when you pick them up
        if (pl.needle == 1 && pl.hasDoll == true)
        {
            voodooDollImage.sprite = oneNeedle;
            VoodooBuff.text = "YOU NOW RUN FASTER";
        }
        else if (pl.needle == 2 && pl.hasDoll == true)
        {
            voodooDollImage.sprite = twoNeedle;
            healthSlider.maxValue = 7;
            VoodooBuff.text = "YOU NOW HAVE MORE HEALTH";
        }
        else if (pl.needle == 3 && pl.hasDoll == true)
        {
            voodooDollImage.sprite = noNeedle;
            VoodooBuff.text = "YOU NOW RELOAD FASTER";
        }

        if (pl.hasKey == true)
        {
            key.SetActive(true);
        }
        else
        {
            key.SetActive(false);
        }

        PlayerShot s = pl.GetComponentInChildren<PlayerShot>();
        if (s.isReloading())
        {
            ammoText.text = "load\n-ing";
        }
        else
        {
            ammoText.text = s.getBullets().ToString();
        }
        hudHealth.value = pl.health;

        if (pl.health <= 0)
        {
            GameOver.SetActive(true);
            hPanel.SetActive(false);
            inventoryGrid.SetActive(false);
            pauseMenuPanel.SetActive(false);
            deaths++;
            GlobalControl.Instance.deaths = deaths;
        }

        if (pl.time > 0f && pl.hasDoll == true)
        {
            VoodooTextObject.SetActive(true);
            pl.time -= Time.deltaTime;
        } else
        {
            VoodooTextObject.SetActive(false);
        }
    }
}