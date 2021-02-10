using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statue : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite regStatue;
    public Sprite altStatue;
    private bool evilStatue;
    public GameObject statueNote;
    public static float targetTime = 13.0f;


    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer.sprite = regStatue;
        evilStatue = false;
        statueNote.name = "RegularStatueNote";
    }

    // Update is called once per frame
    void Update()
    {
        targetTime -= Time.deltaTime;
        if (targetTime <= 0f && Note.evilStatue == true)
        {
            evilStatue = true;
            spriteRenderer.sprite = altStatue;
            statueNote.name = "StatueNote";
        }

    }
}
