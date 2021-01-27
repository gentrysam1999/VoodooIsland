using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HudManager : MonoBehaviour
{

    // References to UI elements on the canvas
    // public Slider hudHealth = null;

    // References to objects that provide
    // information about score, health and
    // the game over condition
    // PlayerHealth healthInfoProvider;
    // Remover gameoverInfoProvider;

    // Health value currently displayed
    float health;

    // Reference to UI panel that is our pause menu
    public GameObject pauseMenuPanel;
    // Reference to panel's script object 
    PauseMenuManager pauseMenu;


    // Use this for initialization
    void Start()
    {
        // Initilaise references to the game objects
        // that provide informaiton about the score,
        // health and game over condition
        //  scoreInfoProvider = FindObjectOfType<Score>();
        // healthInfoProvider = FindObjectOfType<PlayerHealth>();
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

        // Display health - but rather than doing it in one go, change the value
        // gradually (over certain period of time)   
        // health = Mathf.MoveTowards(health, healthInfoProvider.health, 20 * Time.deltaTime);
        // hudHealth.value = health;
        if (Input.GetKey(KeyCode.Escape))
        {
            // If user presses ESC, show the pause menu in pause mode
            pauseMenu.ShowPause();
        }
    }
}