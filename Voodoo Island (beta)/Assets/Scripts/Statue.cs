using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statue : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite regStatue;
    public Sprite altStatue;
    public GameObject statueNote;


    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer.sprite = regStatue;
        statueNote.name = "RegularStatueNote";
        
    }

    // Update is called once per frame
    public void spooky()
    {
        spriteRenderer.sprite = altStatue;
        statueNote.name = "StatueNote";
       
    }
}
