using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmControl : MonoBehaviour
{
    //speed that arms rotate
    public float speed = 5f;

    public bool aimDown = true;
    public bool aimRight = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //gets position of mouse and rotates arms from pivot towards mouse position
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle+88, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);

        Debug.Log(angle);
        //Debug.Log(rotation);

        //check L&R direction of aim
        if (angle < 90  && angle > -90)
        {
            aimRight = true;
        }else
        {
            aimRight = false;
        }

        //check U&D direction of aim
        if (angle > 0)
        {
            aimDown = false;
        }
        else
        {
            aimDown = true;
        }


    }
}
