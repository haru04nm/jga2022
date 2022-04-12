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
        }
        else
        {
            redFlag = true;
        }

        if (blueFlag)
        {
            blueFlag = false;
        }
        else
        {
            blueFlag = true;
        }

        

    }

    private void OnTriggerExit(Collider other)
    {
        onFlag = false;
    }
}
