using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class QuitScript : MonoBehaviour
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
        Time.timeScale = 1;
        SceneManager.LoadScene("Main_Menu");
    }

    public void actionToQuit(int idx)
    {
        Application.Quit();
    }
}
