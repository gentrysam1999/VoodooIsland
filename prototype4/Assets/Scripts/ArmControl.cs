using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmControl : MonoBehaviour
{
    //speed that arms rotate
    public float speed = 15f;

    public bool aimDown = true;
    public bool aimRight = true;
    private SpriteRenderer mySpriteRenderer;

    public

    // Start is called before the first frame update
    void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //gets position of mouse and rotates arms from pivot towards mouse position
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90f;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);

        Debug.Log(angle);
        //Debug.Log(rotation);

        //check L&R direction of aim
        if (angle < 180  && angle > 0)
        {
            aimRight = true;

            if(mySpriteRenderer != null)
            {
                 // flip the sprite
                 mySpriteRenderer.flipX = false;
            }
        }else
        {
            aimRight = false;
            
            if(mySpriteRenderer != null)
            {
                 // flip the sprite
                 mySpriteRenderer.flipX = true;
            }
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
