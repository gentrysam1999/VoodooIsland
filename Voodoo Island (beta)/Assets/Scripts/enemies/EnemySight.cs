using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySight : MonoBehaviour
{ 
    //how far can The enemy see
    public float radius = 4f;

    // Number of points on circle's circumference
    public int numPoints = 128;

    private bool active = false;
    // Use this for initialization
    void Start()
    {

    }

    void Update()
    {

        // Compute the angle between two triangles in the cricle
        float delta = 2f * Mathf.PI / (float)(numPoints - 1);
        // Stat with angle of 0
        float alpha = 0f;

        //Specify the layer mast for ray casting - ray casting will only interact with layer 8
        int playerLayer = 1 << 8;
        int wallLayer = 1 << 9;

        //check 
        bool hasHit = false;


        //Other vertices will be positioned evenly around the circle
        for (int i = 1; i <= numPoints; i++)
        {

            // Compute position x from spherical coordinates
            float x = radius * Mathf.Cos(alpha);
            // Compute position y from spherical coordinates
            float y = radius * Mathf.Sin(alpha);



            // Create a ray
            Vector2 ray = new Vector2(x, y);
            ray.x *= transform.lossyScale.x;
            ray.y *= transform.lossyScale.y;

            // Cast the ray 
            RaycastHit2D playerhit = Physics2D.Raycast(transform.position, ray, ray.magnitude, playerLayer);
            RaycastHit2D wallHit = Physics2D.Raycast(transform.position, ray, ray.magnitude, wallLayer);

            // Check if ray has hit something, if yes, check how far from the ray's origin point
            // and adjust the distance of where the mesh point is going to be located.

          
            if (playerhit.collider != null)
            {
    
                if(playerhit.distance < wallHit.distance+5f)
                {
                    hasHit = true;
                }
          
            }


            // Increase the angle to get the next positon around the circle
            alpha += delta;
        }
        if (hasHit)
        {
            active = true;
        }
        else
        {
            active = false;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        // Compute the angle between two triangles in the cricle
        float delta = 2f * Mathf.PI / (float)(numPoints - 1);
        // Stat with angle of 0
        float alpha = 0f;

        //Other vertices will be positioned evenly around the circle
        for (int i = 1; i <= numPoints; i++)
        {
            //Radius and alpha give a position of a point around
            //the circle in spherical coordinates 

            // Compute position x from spherical coordinates
            float x = radius * Mathf.Cos(alpha);
            // Compute position y from spherical coordinates
            float y = radius * Mathf.Sin(alpha);

            // Create a ray
            Vector3 ray = new Vector3(x, y, transform.position.z);

            ray.x *= transform.lossyScale.x;
            ray.y *= transform.lossyScale.y;

            Gizmos.DrawRay(transform.position, ray);

            // Increase the angle to get the next positon around the circle
            alpha += delta;
        }
    }
    public bool isActive()
    {
        return active;
    }

}
