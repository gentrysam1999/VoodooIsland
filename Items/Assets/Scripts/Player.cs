using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed = 10;

    private bool hasKey = false;

    private bool canPickUp = false;

    private UnityEngine.Object key; 

    void OnTriggerEnter2D(Collider2D other)
    {
        //Check if key
        if (other.tag == "Key")
        {
            key = other.gameObject;
            canPickUp = true;

        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Key")
        {
            canPickUp = false;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {

        if(other.gameObject.tag == "Door" && hasKey)
        {
            hasKey = false;
            Destroy(other.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        float var = Time.deltaTime * speed;

        transform.Translate(new Vector3(var * horizontalMovement, var * verticalMovement, 0));

        if(canPickUp && Input.GetKeyDown(KeyCode.E))
        {
            hasKey = true;
            canPickUp = false;
            Destroy(key);
        }
    }
}
