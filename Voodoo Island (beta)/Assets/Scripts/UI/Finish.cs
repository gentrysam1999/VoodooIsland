using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Finish : MonoBehaviour
{
    public Text statsText;
    // Start is called before the first frame update
    void Start()
    {
        int ammo = GlobalControl.Instance.Ammo;
        int health = GlobalControl.Instance.HP;
        int needle = GlobalControl.Instance.needle;
        bool hasDoll = GlobalControl.Instance.hasDoll;
        float speed = GlobalControl.Instance.speed;
        int bulletsFired = GlobalControl.Instance.bulletsFired;

        string stats = "YOU WIN\n\n";
        stats += "Big Jim found his parents, trapped in the nursery. \nHaving freed them, Jim burned the mansion to the ground, laying the voodoo curse to rest... for now!\n";
        stats += "YOU FIRED: " + bulletsFired + " BULLETS";
        stats += "YOU PICKED UP: " + needle + " NEEDLES\n";

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
