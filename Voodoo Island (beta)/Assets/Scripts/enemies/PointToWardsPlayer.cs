using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointToWardsPlayer : MonoBehaviour
{

    private Transform target;
    // Start is called before the first frame update
    void Start()
    {
        Shooting w = gameObject.transform.parent.parent.GetComponentInParent<Shooting>();
        target = w.player;
    }

    // Update is called once per frames
    void Update()
    {
        Vector3 myPosition = transform.position;
        Vector3 targetPosistion = target.position;

        myPosition.z = 0f;
        myPosition.x = myPosition.x - targetPosistion.x;
        myPosition.y = myPosition.y - targetPosistion.y;

        float angle =  Mathf.Atan2(myPosition.y, myPosition.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle-90f));    



    }
}
