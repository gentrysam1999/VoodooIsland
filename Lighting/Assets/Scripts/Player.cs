using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{


    public float speed;

    public float low_intensity = 0.75f;
    public float high_intensity = 2f;

    Light flashlight;

    bool atTopWall = false;

    int timeLeft = -1;

    bool atTopWall2 = false;

    // Flag indicating whether the player is at the 
    // right edge of the screen
    bool atBottomWall = false;
    bool atBottomWall2 = false;

    void Start()
    {
        flashlight = GetComponent<Light>();
        if (PlayerPrefs.HasKey("GB_light"))
        {
            flashlight.intensity = 0.75f;
        }
    }

    // On collision with a trigger collider...
    void OnTriggerEnter2D(Collider2D other)
    {
        // Check the tag of the object the player
        // has collided with
        if (other.tag == "TopWall")
        {
            // If collided with the top wall, move to second scene.
            SceneManager.LoadScene("level2");
        }
        else if (other.tag == "BottomWall")
        {
            SceneManager.LoadScene("level1");
            // If collided with the right wall, set
            // the right wall flag to true

        }
        else if (other.tag == "TopWall2")
        {
            SceneManager.LoadScene("level3");
            // If collided with the right wall, set
            // the right wall flag to true

        }
        else if (other.tag == "BottomWall2")
        {
            SceneManager.LoadScene("level2");
            // If collided with the right wall, set
            // the right wall flag to true
        }
    }

    // When no longer colliding with an object...
    void OnTriggerExit2D(Collider2D other)
    {
        // Check the tag of the object the player
        // has ceased to collide with
        if (other.tag == "BottomWall")
        {
            // If collided with the left wall, set
            // the left wall flag to true
            atBottomWall = false;
        }
        else if (other.tag == "TopWall")
        {
            // If collided with the right wall, set
            // the right wall flag to true
            atTopWall = false;
        }
        else if (other.tag == "TopWall2")
        {
            // If collided with the right wall, set
            // the right wall flag to true
            atTopWall2 = false;
        }
        else if (other.tag == "BottomWall2")
        {
            // If collided with the right wall, set
            // the right wall flag to true
            atBottomWall2 = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float delta = speed * Time.deltaTime;

        if (Input.GetKey(KeyCode.D))
        {
            // Move to the right
            transform.Translate(new Vector3(speed * delta, 0, 0));
        }
        else if (Input.GetKey(KeyCode.A))
        {
            // Move to the left
            transform.Translate(new Vector3(-speed * delta, 0, 0));
        }
        else if (Input.GetKey(KeyCode.W))
        {
            // Move up
            transform.Translate(new Vector3(0, speed * delta, 0));
        }
        else if (Input.GetKey(KeyCode.S))
        {
            //Move down
            transform.Translate(new Vector3(0, -speed * delta, 0));
        }
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            HudManager.AmmoDown();
        }
        // If close to wall and moving towards it,
        // stop the movment
        if (atBottomWall)
        {
            SceneManager.LoadScene("level1");
        }
        if (atTopWall)
        {
            SceneManager.LoadScene("level2");
        }
        if (atTopWall2)
        {
            SceneManager.LoadScene("level3");
        }
        if (atBottomWall2)
        {
            SceneManager.LoadScene("level2");
        }

        if (timeLeft > 0)
        {
            timeLeft -= 1;
        } else if(timeLeft == 0)
        {
            flashlight.intensity = low_intensity;
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (flashlight.intensity == low_intensity)
            {
                flashlight.intensity = high_intensity;
            }
            else
            {
                flashlight.intensity = low_intensity;
            }
            PlayerPrefs.SetFloat("GB_light", flashlight.intensity);
        }
    }
}