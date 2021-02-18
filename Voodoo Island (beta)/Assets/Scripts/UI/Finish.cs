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
    int deaths;

    // Start is called before the first frame update
    void Start()
    {
        needle = GlobalControl.Instance.needle;
        hasDoll = GlobalControl.Instance.hasDoll;
        bulletsFired = GlobalControl.Instance.bulletsFired;
        deaths = GlobalControl.Instance.deaths;
        healthPickUpsUsed = GlobalControl.Instance.healthPickUpsUsed;

    string stats = "YOU WIN\n\n";
        stats += "YOU FIRED: " + bulletsFired + " BULLETS\n";
        if (needle == 1)
        {
            stats += "YOU FOUND AND DESTROYED: " + needle + " NEEDLE\n";
        }
        else
        {
            stats += "YOU FOUND AND DESTROYED: " + needle + " NEEDLES\n";
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
        if (deaths == 1)
        {
            stats += "YOU DIED: " + deaths + " TIME\n";
        }
        else
        {
            stats += "YOU DIED: " + deaths + " TIMES\n";
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
