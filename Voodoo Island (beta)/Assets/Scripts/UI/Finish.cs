using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Finish : MonoBehaviour
{
    public Text statsText;
    int bulletsFired;
    bool hasDoll;
    int needle;

    // Start is called before the first frame update
    void Start()
    {
        needle = GlobalControl.Instance.needle;
        hasDoll = GlobalControl.Instance.hasDoll;
        bulletsFired = GlobalControl.Instance.bulletsFired;

        string stats = "YOU WIN\n\n";
        stats += "Big Jim staggered away from the Witch, and looked upon the accursed mansion he had struggled through. \nThe mansion was collapsing in on itself, burying the voodoo curse ... for now!\n\n";
        stats += "YOU FIRED: " + bulletsFired + " BULLETS\n";
        stats += "YOU PICKED UP: " + needle + " NEEDLES\n";
        if (hasDoll == true)
        {
            stats += "YOU FOUND THE DOLL\n";
        } else
        {
            stats += "YOU IGNORED THE DOLL\n";
        }

        statsText.text = stats;

    }

    public void backtoMain()
    {
        SceneManager.LoadScene("MainMenu");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
