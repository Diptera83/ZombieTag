using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LinkButtonScript : MonoBehaviour
{
    

    private void Start()
    {
       
    }
    void OnMouseDown()
    {
   
        Application.OpenURL("http://www.dipteragames.com/");
    }

    // Update is called once per frame
    void Update()
    {
      
    }
}
