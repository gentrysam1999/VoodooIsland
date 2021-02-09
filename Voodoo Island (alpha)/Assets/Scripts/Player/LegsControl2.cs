using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegsControl2 : MonoBehaviour
{
    public Sprite[] forwardAnimSprites;
    public Sprite[] sideAnimSprites;

    public Sprite idleSprite;

    public float framesPerSecond;

    SpriteRenderer animRenderer;

    private float timeAtAnimStart;
    // Start is called before the first frame update
    void Start()
    {
        animRenderer = GetComponent<Renderer>() as SpriteRenderer;
    }

    // Update is called once per frame
    void Update()
    {
        float userInputX = Input.GetAxis("Horizontal");
        float userInputY = Input.GetAxis("Vertical");

        //if moving left or right
        if (userInputX != 0){
            float timeSinceAnimStart = Time.timeSinceLevelLoad - timeAtAnimStart;
            int frameIndex = (int)(timeSinceAnimStart * framesPerSecond);

            //check which direction to face
            if (userInputX < 0f)
            {
                animRenderer.flipX = true;
            }
            else
            {
                animRenderer.flipX = false;
            }

            
            if (frameIndex < sideAnimSprites.Length)
            {
                // Let the renderer know which sprite to use next      
                animRenderer.sprite = sideAnimSprites[frameIndex];
            }
            else
            {
                animRenderer.sprite = sideAnimSprites[0];
                timeAtAnimStart = Time.timeSinceLevelLoad;
            }
            
        }else if (userInputY != 0){
            float timeSinceAnimStart = Time.timeSinceLevelLoad - timeAtAnimStart;
            int frameIndex = (int)(timeSinceAnimStart * framesPerSecond);

            if (frameIndex < forwardAnimSprites.Length)
            {
                // Let the renderer know which sprite to use next      
                animRenderer.sprite = forwardAnimSprites[frameIndex];
            }
            else
            {
                animRenderer.sprite = forwardAnimSprites[0];
                timeAtAnimStart = Time.timeSinceLevelLoad;
            }
        } else{
            animRenderer.sprite = idleSprite;
        }
    }
}
