using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public KeyCode moveLeft;
    public KeyCode moveRight;
    public KeyCode moveUp;
    public KeyCode moveDown;

    public float speed;

    bool atTopWall = false;

    bool atTopWall2 = false;

    // Flag indicating whether the player is at the 
    // right edge of the screen
    bool atBottomWall = false;
    bool atBottomWall2 = false;

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

            if (Input.GetKey(moveRight))
            {
                // Move to the right
                transform.Translate(new Vector3(speed * delta, 0, 0));
            }
            else if (Input.GetKey(moveLeft))
            {
                // Move to the left
                transform.Translate(new Vector3(-speed * delta, 0, 0));
            }
            else if (Input.GetKey(moveUp))
            {
                //Rotate counterclockwise
                transform.Rotate(new Vector3(0, 0, speed * delta * 10));
            }
            else if (Input.GetKey(moveDown))
            {
                //Rotate clockwise
                transform.Rotate(new Vector3(0, 0, -speed * delta * 10));
            }

            // If close to wall and moving towards it,
            // stop the movment
            if (atBottomWall) {
                SceneManager.LoadScene("level1");
            }
            if (atTopWall) {
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
        }
    }