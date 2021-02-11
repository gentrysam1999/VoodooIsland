using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Credits : MonoBehaviour
{
    float speed = 0.2f;
    bool crawling = false;
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

        crawling = true;
    }

    public void backtoMain()
    {
        SceneManager.LoadScene("MainMenu");
    }

    void Update()
    {
     if (!crawling)
     {
      return;
     }
     transform.Translate(Vector3.up * Time.deltaTime * speed);
     // if (gameObject.transform.position.y > .8)
     // {
       // crawling = false;
     // }
    }
  }
