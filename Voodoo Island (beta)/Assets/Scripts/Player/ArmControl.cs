using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmControl : MonoBehaviour
{
    //speed that arms rotate
    public float speed = 15f;

    public bool aimDown = true;
    public bool aimRight = true;
    private SpriteRenderer armsRend;

    public Sprite[] head;
    public Sprite[] hat;
    public Sprite[] body;
    public Sprite[] arm;
    public Sprite[] shoulder;

    public SpriteRenderer headRend;
    public SpriteRenderer hatRend;
    public SpriteRenderer bodyRend;
    public SpriteRenderer shoulderRend;


    public

    // Start is called before the first frame update
    void Start()
    {
        armsRend = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        //gets position of mouse and rotates arms from pivot towards mouse position
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90f;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);

        //Debug.Log(angle);
        //Debug.Log(rotation);

        //check L&R direction of aim
        if (angle < 180  && angle > 0)
        {
            aimRight = true;
            armsRend.flipX = false;
            
        }else
        {
            aimRight = false;
            armsRend.flipX = true;
            
        }

        //check U&D direction of aim
        if (angle > -90 && angle < 90)
        {
            aimDown = true;
            //headRend.sprite = head[0];
        }
        else
        {
            aimDown = false;
            //headRend.sprite = head[2];
        }

        if (angle > -45 && angle < 45){
            //face forward
            headRend.sprite = head[0];
            bodyRend.sprite = body[0];
            hatRend.sprite = hat[0];
            armsRend.sprite = arm[0];
            shoulderRend.sprite = shoulder[0];
        }
        else if (angle > 45 && angle < 135){
            //face right
            headRend.flipX = false;
            hatRend.flipX = false;
            headRend.sprite = head[1];
            bodyRend.sprite = body[1];
            hatRend.sprite = hat[1];
            armsRend.sprite = arm[1];
            shoulderRend.sprite = shoulder[1];
        } else if(angle > 135 && angle < 225){
            //face up
            headRend.sprite = head[2];
            bodyRend.sprite = body[2];
            hatRend.sprite = hat[2];
            armsRend.sprite = arm[0];
            shoulderRend.sprite = shoulder[0];
        }else{
            //face left
            headRend.flipX = true;
            hatRend.flipX = true;
            headRend.sprite = head[1];
            bodyRend.sprite = body[3];
            hatRend.sprite = hat[1];
            armsRend.sprite = arm[1];
            shoulderRend.sprite = shoulder[1];
        } 
        

    }
}
