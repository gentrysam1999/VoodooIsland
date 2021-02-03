using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegsControl : MonoBehaviour
{
    // An array with the sprites used for animation
    public Sprite[] forwardAnimSprites;
    public Sprite[] sideAnimSprites;

    public Sprite idleSprite;

    // Controls how fast to change the sprites when
    // animation is running
    public float framesPerSecond;

    // Reference to the renderer of the sprite
    // game object
    SpriteRenderer animRenderer;
    
    // Time passed since the start of animatin
    private float timeAtAnimStart;
    
    // Indicates whether animation is running or not
    private bool animRunningForward = false;
    private bool animRunningSide = false;

    private bool idle = true;

    // Start is called before the first frame update
    void Start()
    {
        // Get a reference to game object renderer and
        // cast it to a Sprite Renderer
        animRenderer = GetComponent<Renderer>() as SpriteRenderer;
    }

    void FixedUpdate () {
        if(!animRunningForward && !animRunningSide) {
            // The animation is triggered by user input
            float userInputX = Input.GetAxis("Horizontal");
            float userInputY = Input.GetAxis("Vertical");
            if (userInputX != 0f) {
                //User pressed move left or move right button

                if (userInputX < 0f)
                {
                    animRenderer.flipX = true;
                }
                else
                {
                    animRenderer.flipX = false;
                }
                //Animation will start playing
                animRunningSide = true;

                // Record time at animation start
                timeAtAnimStart = Time.timeSinceLevelLoad;

                //player is moving
                idle = false;
            }else if (userInputY != 0f) {
                // User pressed the move up or down button
                
                // Animation will start playing
                animRunningForward = true;
                
                // Record time at animation start
                timeAtAnimStart = Time.timeSinceLevelLoad;

                //player is moving
                idle = false;
            }else{
                //player is stopped
                idle = true;
                animRunningForward = false;
                animRunningSide = false;
                
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        float userInputX = Input.GetAxis("Horizontal");
        float userInputY = Input.GetAxis("Vertical");


        if (idle){
            animRenderer.sprite = idleSprite;
        }
        else{
            if (animRunningSide && userInputX != 0f)
            {
                float timeSinceAnimStart = Time.timeSinceLevelLoad - timeAtAnimStart;
                int frameIndex = (int)(timeSinceAnimStart * framesPerSecond);

                if (frameIndex < sideAnimSprites.Length)
                {
                    // Let the renderer know which sprite to
                    // use next      
                    animRenderer.sprite = sideAnimSprites[frameIndex];
                }
                else
                {
                    animRenderer.sprite = sideAnimSprites[0];
                    animRunningSide = false;
                }
            }
            else if (animRunningForward && userInputY != 0f)
            {
                // Animation is running, so we need to 
                // figure out what frame to use at this point
                // in time

                // Compute number of seconds since animation started playing
                float timeSinceAnimStart = Time.timeSinceLevelLoad - timeAtAnimStart;

                // Compute the index of the next frame    
                int frameIndex = (int)(timeSinceAnimStart * framesPerSecond);

                if (frameIndex < forwardAnimSprites.Length)
                {
                    // Let the renderer know which sprite to
                    // use next      
                    animRenderer.sprite = forwardAnimSprites[frameIndex];


                }
                else
                {
                    // Animation finished, set the render
                    // with the idle sprite and stop the 
                    // animation
                    animRenderer.sprite = forwardAnimSprites[0];
                    animRunningForward = false;
                }
            }
            else
            {
                animRunningForward = false;
                animRunningSide = false;
            }
        }
    }
}
