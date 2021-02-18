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
        string message1 = "After months of radio silence from his family, our heroic police officer, Big Jim, finally returned home to his family's island to figure out why they had cut all contact with him.\n\n However, instead of finding his family, Big Jim was quickly confronted by a mysterious presence which had taken over control of his family home.\n\n";
        message1 += "Isolated and cut off from civilization, Big Jim now has no choice but to plunge forwards into his old home, in an effort to save those he cares about from the secrets of the Voodoo Mansion...\n\n";
        string message2 = "\nPRESS ANY KEY TO CONTINUE";

        statsText.text = message1;
        statsText2.text = message2;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene("Area1");
        }
    }
}