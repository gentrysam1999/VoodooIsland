using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Credits : MonoBehaviour
{
    public Text creditText;

    void Start()
    {
        // init text here, more space to work than in the Inspector (but you could do that instead)
        string creds = "TEAM CHAMELEON\n\n";
        creds += "Art Director:\nSam Gentry\n";
        creds += "Game Design:\nJacob Cone\n";
        creds += "Programming:\nSean Cartman\n";
        creds += "Level Design / Artist:\nCastipher McSkimming\n";

        creditText.text = creds;

    }

    public void backtoMain()
    {
        SceneManager.LoadScene("MainMenu");
    }

    void Update()
    {

    }
}