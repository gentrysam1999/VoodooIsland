using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform player;

    private Vector2 camView;

    private Vector3 mousePoint;

    [Range(1, 3)]
    public float camMoveValue = 1.5f;

    void Start()
    {
        transform.position = new Vector3(player.position.x, player.position.y, -10);
    }

    // Update is called once per frame
    void Update()
    {

        mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Debug.Log(mousePoint);
        //camView = new Vector2(mousePoint.x - player.position.x, mousePoint.y - player.position.y);
        //Debug.Log(player.position);
        //Debug.Log(camView);s
        //transform.position = new Vector3 (player.position.x, player.position.y, -10);


        float screenW = Camera.main.pixelWidth;
        float screenH = Camera.main.pixelHeight;

        Vector3 leftBottom = Camera.main.ScreenToWorldPoint(new Vector3(0f, 0f, 0f));
        Vector3 leftTop = Camera.main.ScreenToWorldPoint(new Vector3(0f, screenH, 0f));

        Vector3 rightBottom = Camera.main.ScreenToWorldPoint(new Vector3(screenW, 0f, 0f));
        Vector3 rightTop = Camera.main.ScreenToWorldPoint(new Vector3(screenW, screenH, 0f));




        float mousePointX = maxMouseValues(rightTop.x,leftBottom.x, mousePoint.x);
        float mousePointY = maxMouseValues(leftTop.y,leftBottom.y, mousePoint.y);

        camView.x = moveCamOnAxis(mousePointX, player.position.x);


        camView.y = moveCamOnAxis(mousePointY, player.position.y);

        transform.position = new Vector3(camView.x, camView.y, -10);
    }


    //get the value for cam view to move on one axis. 
    private float moveCamOnAxis(float point, float position)
    {

        float cam = point;
        cam += (position - point)/camMoveValue;
        return cam;

    }
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
