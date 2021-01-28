using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Movement : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
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
    }
}
