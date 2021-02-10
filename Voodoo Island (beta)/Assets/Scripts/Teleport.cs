using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        //Check if the player is on a key and allow the player to pick up a key
        if (other.tag == "Hall1")
        {
            SceneManager.LoadScene("Area2");
        }
        else if (other.tag == "Living")
        {
            SceneManager.LoadScene("Area3");
        }
        else if (other.tag == "Jetty")
        {
            SceneManager.LoadScene("Area4");
        }
    }
}
