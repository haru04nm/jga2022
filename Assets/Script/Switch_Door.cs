using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch_Door : MonoBehaviour
{
    public static bool redFlag;
    public static bool blueFlag;

    bool onFlag;

    private void Start()
    {
        blueFlag = false;
        redFlag = true;
    }

    private void OnTriggerEnter(Collider other)
    {
                
        if (redFlag)
        {
            redFlag = false;
            Debug.Log("redFlag = "+ redFlag);
        }
        else
        {
            redFlag = true;
            Debug.Log("redFlag = " + redFlag);
        }

        if (blueFlag)
        {
            blueFlag = false;
            Debug.Log("blueFlag = "+blueFlag);
        }
        else
        {
            blueFlag = true;
            Debug.Log("blueFlag = " + blueFlag);
        }

        

    }

    private void OnTriggerExit(Collider other)
    {
        onFlag = false;
    }
}
