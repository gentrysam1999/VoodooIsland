using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalControl : MonoBehaviour
{
    public static GlobalControl Instance;


    public int HP = 5;
    public int Ammo = 24;
    public int needle = 0;
    public bool hasDoll;
    public float speed = 25;
    public int bulletsFired;
    public int healthPickUpsUsed;
    public int deaths;
    public int healthMax;
    public int level = 0;

    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
}
