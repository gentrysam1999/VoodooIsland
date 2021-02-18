using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Intro : MonoBehaviour
{

    public Text statsText;
    public Text statsText2;
    // Start is called before the first frame update
    void Start()
    {
        string message1 = "After months of radio silence from his family, our heroic police officer, Big Jim finally returned home to his family's island to figure out why they had cut all contact with him. However instead of finding his family, Big Jim was confronted by a mysterious presence which had taken over control of his family home.";
        string message2 = "\npress enter to continue";

        statsText.text = message1;
        statsText2.text = message2;
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