using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Finish : MonoBehaviour
{
    public Text stats;
    // Start is called before the first frame update
    void Start()
    {
        int ammo = GlobalControl.Instance.Ammo;
        int health = GlobalControl.Instance.HP;
        int needle = GlobalControl.Instance.needle;
        bool hasDoll = GlobalControl.Instance.hasDoll;
        float speed = GlobalControl.Instance.speed;
        int bulletsFired = GlobalControl.Instance.bulletsFired;

        string stat = "YOU WIN\n\n";
        stat += "Big Jim found his parents, trapped in the nursery. \nHaving freed them, Jim burned the mansion to the ground, laying the voodoo curse to rest... for now!\n";
        stat += "YOU FIRED: " + bulletsFired + " BULLETS";
        stat += "YOU PICKED UP: " + needle + " NEEDLES\n";

        stats.text = stat;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
