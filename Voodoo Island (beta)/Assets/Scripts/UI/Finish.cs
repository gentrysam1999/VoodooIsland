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
    int healthPickUpsUsed;

    // Start is called before the first frame update
    void Start()
    {
        needle = GlobalControl.Instance.needle;
        hasDoll = GlobalControl.Instance.hasDoll;
        bulletsFired = GlobalControl.Instance.bulletsFired;
        int healthPickUpsUsed = GlobalControl.Instance.healthPickUpsUsed;

    string stats = "YOU WIN\n\n";
        stats += "Big Jim staggered away from the Witch, and looked upon the accursed mansion he had struggled through. \nThe mansion was collapsing in on itself, burying the voodoo curse ... for now!\n\n";
        stats += "YOU FIRED: " + bulletsFired + " BULLETS\n";
        if (needle == 1)
        {
            stats += "YOU PICKED UP: " + needle + " NEEDLE\n";
        }
        else
        {
            stats += "YOU PICKED UP: " + needle + " NEEDLES\n";
        }
        if (hasDoll == true)
        {
            stats += "YOU FOUND THE DOLL\n";
        }
        else
        {
            stats += "YOU IGNORED THE DOLL\n";
        }
        stats += "YOU USED: " + healthPickUpsUsed + " HEALTH PICKUPS\n";

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
