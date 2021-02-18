using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    //Main menu
    public void StartGame()
    {
        // Load the first area
        int needle = 0;
        GlobalControl.Instance.needle = needle;
        int health = 5;
        GlobalControl.Instance.HP = health;
        GlobalControl.Instance.hasDoll = false;
        GlobalControl.Instance.bulletsFired = 0;
        GlobalControl.Instance.healthPickUpsUsed = 0;
        GlobalControl.Instance.deaths = 0;
        SceneManager.LoadScene("intro");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void QuitGame()
    {
        // Quit the application
        Application.Quit();
    }




    //level selects
    public void SceneSelect()
    {
        SceneManager.LoadScene("SceneSelect");
    }
    public void Area1()
    {
        SceneManager.LoadScene("Area1");
    }

    public void Area2()
    {
        SceneManager.LoadScene("Area2");
    }

    public void Area3()
    {
        SceneManager.LoadScene("Area3");
    }

    public void Area4()
    {
        SceneManager.LoadScene("Area4");
    }
}