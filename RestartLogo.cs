using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartLogo : MonoBehaviour
{
    public int index;

    private Button myselfButton;
    
    // Start is called before the first frame update
    void Start()
    {
        myselfButton = GetComponent<Button>();
    }

   

   public void actionToMaterial(int idx)
    {
        Time.timeScale = 1.0f;
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "Level1")
        {
            SceneManager.LoadScene("Level1");
        }
        else if(scene.name=="Level_2")
        {
            SceneManager.LoadScene("Level_2");
        }
        else if (scene.name == "Level_3")
        {
            SceneManager.LoadScene("Level_3");
        }
        else if (scene.name == "Level_4")
        {
            SceneManager.LoadScene("Level_4");
        }
    }
}
