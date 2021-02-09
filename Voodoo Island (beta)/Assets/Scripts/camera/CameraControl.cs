using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    // Start is called before the first frame update

    //big jims location
    public Transform player;

    //a Vector2 holding where the camera will be moved too 
    private Vector2 camView;

    //the location of the mouse
    private Vector3 mousePoint;


    //on one 1 the camera will follow big jim
    //on 2 the camera will follow the mouse mostly and big jim a little
    //set to any value inbetween
    [Range(1, 2)]
    public float camMoveValue = 1.5f;

    void Start()
    {
        //move the camera too big jim at sceen start
        transform.position = new Vector3(player.position.x, player.position.y, -10);
    }

    // Update is called once per frame
    void Update()
    {

        mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        //Code to find the the edges of the screen, adapted from lab4
        float screenW = Camera.main.pixelWidth;
        float screenH = Camera.main.pixelHeight;
        Vector3 leftBottom = Camera.main.ScreenToWorldPoint(new Vector3(0f, 0f, 0f));
        Vector3 leftTop = Camera.main.ScreenToWorldPoint(new Vector3(0f, screenH, 0f));
        Vector3 rightBottom = Camera.main.ScreenToWorldPoint(new Vector3(screenW, 0f, 0f));
        Vector3 rightTop = Camera.main.ScreenToWorldPoint(new Vector3(screenW, screenH, 0f));

        //check if the mouse is on the screen. 
        float mousePointX = maxMouseValues(rightTop.x,leftBottom.x, mousePoint.x);
        float mousePointY = maxMouseValues(leftTop.y,leftBottom.y, mousePoint.y);

        //Find the new postion for the camera for the X and Y axis
        camView.x = moveCamOnAxis(mousePointX, player.position.x);
        camView.y = moveCamOnAxis(mousePointY, player.position.y);

        //move the camera
        if (Time.timeScale != 0)
        {
            transform.position = new Vector3(camView.x, camView.y, -20);
        }
    }


    //get the value for cam view to move on one axis.
    //@param point where the mouse is on the given axis
    //@param position where the Big Jim is based on  given AXIS
    //both param need to be on either X or Y axis
    //return a values inbetween for the camera to go too. 
    private float moveCamOnAxis(float point, float position)
    {

        float cam = point;
        cam += (position - point)/camMoveValue;
        return cam;

    }

    //Stop moving the camera when the mouse goes of screen.
    //all params need to be on the same axis
    //@param top, the top of the screen in  worlds points
    //@param bottom, the bottom of the screen
    //@param mouse, the location of the mouse
    //if the mouse is off the screen, return the edge of the screen.
    //if not return the mouse location. 
    private float maxMouseValues(float top, float bottom ,float mouse)
    {
        if (top < mouse)
        {
            return top;
        }
        else if(bottom > mouse)
        {
            return bottom;
        }

        else
        {
            return mouse;
        }
    }
}
