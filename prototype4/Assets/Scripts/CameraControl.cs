using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    // Start is called before the first frame update

public Transform player;
    private Vector2 camView;

    void Start()
    {
        transform.position = new Vector3(player.position.x, player.position.y, -10);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log(mousePoint);
        //camView = new Vector2(mousePoint.x - player.position.x, mousePoint.y - player.position.y);
        //Debug.Log(player.position);
        //Debug.Log(camView);
        //transform.position = new Vector3 (player.position.x, player.position.y, -10);
        
        camView.x = mousePoint.x + (player.position.x - mousePoint.x) / 2;
        camView.y = mousePoint.y + ((player.position.y - mousePoint.y) / 2);
        transform.position = new Vector3(camView.x, camView.y, -10);
    }
}
