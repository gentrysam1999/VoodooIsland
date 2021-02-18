using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class End : MonoBehaviour
{

    public Text statsText;
    // Start is called before the first frame update
    void Start()
    {
        string message = "Big Jim staggered away from the Witch, and looked upon the accursed mansion he had struggled through. \nThe mansion was collapsing in on itself, burying the voodoo curse ... for now!\n\n";
        message += "press enter for stats";

        statsText.text = message;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("return"))
        {
            SceneManager.LoadScene("Finish");
        }
    }
}
