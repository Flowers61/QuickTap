using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;


public class PlayerControls : MonoBehaviour
{

    

    private Touch touch;

    public int TapCounter; //playerinput
   

    // Update is called once per frame
    void Update()
    {
        

       
            if (Input.touchCount > 0)
            {
                touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    TapCounter++;
                }
            }

          
    }
}
