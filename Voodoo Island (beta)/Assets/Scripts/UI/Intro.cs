using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Intro : MonoBehaviour
{

    public Text statsText;
    // Start is called before the first frame update
    void Start()
    {
        string message1 = "After months of radio silence from his family, Big Jim finally returned home to his family's island, only to find that a mysterious presence had taken over his home";
        message1 += "press enter to continue";

        statsText.text = message1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("return"))
        {
            SceneManager.LoadScene("Area1");
        }
    }
}