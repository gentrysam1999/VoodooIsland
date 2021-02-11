using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{
    private Player player;

    private void Start()
    {
        player = GetComponent<Player>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
        
        //Check if the player is on a key and allow the player to pick up a key
        if (other.tag == "Hall1")
        {
            SceneManager.LoadScene("Area2");
            player.SavePlayer();
        }
        else if (other.tag == "Living")
        {
            SceneManager.LoadScene("Area3");
            player.SavePlayer();
        }
        else if (other.tag == "Jetty")
        {
            SceneManager.LoadScene("Area4");
            player.SavePlayer();
        }
    }
}
