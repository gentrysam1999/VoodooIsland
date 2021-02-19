using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AreaSelect : MonoBehaviour
{
    private Button button;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();

        if(gameObject.name == "Button1")
        {
            button.interactable = GlobalControl.Instance.level >= 0;
        }
        else if (gameObject.name == "Button2")
        {
            button.interactable = GlobalControl.Instance.level >= 1;
        }
        else if (gameObject.name == "Button3")
        {
            button.interactable = GlobalControl.Instance.level >= 2;
        }
        else if (gameObject.name == "Button4")
        {
            button.interactable = GlobalControl.Instance.level >= 3;
        }
    }

    
}
