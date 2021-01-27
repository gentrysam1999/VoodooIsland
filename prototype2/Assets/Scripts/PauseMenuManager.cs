using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour
{

    // References to text objects on the panel
    public Text resumeText = null;
    public Text quitText = null;

    // Array storing text objct with index
    // indicating the current selection
    int optionIdx = 0;
    Text[] optionArray;

    // Indicates whether the game in paused mode
    bool pauseGame;

    // Use this for initialization
    void Start()
    {
        // We have two text object in the panel,
        // so create an array with 2 references
        // and set the first referect ot resumeText
        // and second reference to quitText
        optionArray = new Text[2];
        optionArray[0] = resumeText;
        optionArray[1] = quitText;
    }

    // Show the pause menu in pause mode (the
    // first option will say "Resume")
    public void ShowPause()
    {
        // Pause the game
        pauseGame = true;
        // Set the text of the first option
        // to "Resume"
        resumeText.text = "Resume";
        // Show the panel
        gameObject.SetActive(true);
    }

    // Show the pause menu in game over mode (the
    // first option will say "Restart"
    public void ShowGameOver()
    {
        // Set the text of the first option
        // to "Restart"
        resumeText.text = "Restart";
        // Show the panel
        gameObject.SetActive(true);
    }


    // Hide the menu panel
    public void Hide()
    {
        // Deactivate the panel
        gameObject.SetActive(false);
        // Resume the game (if paused)
        pauseGame = false;
        Time.timeScale = 1f;
    }


    // Execute a command base on command string (that string
    // corresponds to text of the entered option
    void ExecuteCommand(string command)
    {

        switch (command)
        {

            // For resume option, just hide the panel
            // (the pausegame flag will be set to false)
            case "Resume":
                Hide();
                break;

            // For the restart option just reload current scene
            case "Restart":
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                break;

            // For the quit option load the main menu scene         
            case "Quit":
                SceneManager.LoadScene("MainMenu");
                break;

        }
    }

    // Update is called once per frame
    void Update()
    {
        // Get a reference to the currently selected text box   
        Text currentSelection = optionArray[optionIdx];

        if (Input.GetKey(KeyCode.DownArrow))
        {
            // When user presses down arrow, go to next option
            optionIdx++;
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            // When user presses up arrow, go to previous option
            optionIdx--;
        }
        else if (Input.GetKey(KeyCode.Return) || (Input.GetAxis("Jump") != 0f))
        {
            // If uses presses Enter or "Jump" key (Space), execute
            // the command corresponding to the current option
            ExecuteCommand(currentSelection.text);
        }

        // Make sure that the option index indicator is within the range
        // of the number of options
        if (optionIdx < 0)
        {
            optionIdx = 0;
        }
        else if (optionIdx >= optionArray.Length)
        {
            optionIdx = optionArray.Length - 1;
        }
        // Set the font colour of the currently selected text box
        // to yellow
        currentSelection.color = Color.yellow;

        // If game is in pause mode, stop the timeScale value to 0
        if (pauseGame)
        {
            Time.timeScale = 0;
        }
    }
}