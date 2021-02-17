using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
    

public class SeanDoor : MonoBehaviour
{
    public GameObject box;
    private NavMeshObstacle navmeshobstacle;
    // Start is called before the first frame update
    void Start()
    {
        navmeshobstacle = GetComponent<NavMeshObstacle>();
    }

    // Update is called once per frame
    void Update()
    {
        if (navmeshobstacle.enabled)
        {
            box.tag = "Wall";
            box.layer = 9;
        }
        else
        {
            box.tag = "Untagged";
            box.layer = 0;
        }
    }
}
