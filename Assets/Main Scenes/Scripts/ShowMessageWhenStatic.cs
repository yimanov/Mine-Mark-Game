using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShowMessageWhenStatic : MonoBehaviour
{
    public int time = 0;
    public GameObject objectShowStatic;
    public GameObject mainObject;
     
    void Awake()
    {
        DontDestroyOnLoad(objectShowStatic);
        DontDestroyOnLoad(mainObject);
     

    }

    public void MakeItWithButton()
    {
        objectShowStatic.SetActive(false);
        time = 0;

    }
    void FixedUpdate()
    {

        if (!Input.anyKey)
        {

            //Starts counting when no button is being pressed
            time = time + 1;
        }
        else
        {

            // If a button is being pressed restart counter to Zero

            Debug.Log("100 frames passed with no input");
        }

        //Now after 100 frames of nothing being pressed it will do activate this if statement
        if (time == 1000)
        {
            Debug.Log("100 frames passed with no input");
            objectShowStatic.SetActive(true);
            //Now you could set time too zero so this happens every 100 frames
            time = 0;
        }

    }
}
