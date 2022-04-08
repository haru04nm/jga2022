using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch_Door : MonoBehaviour
{
    public static bool blueFlag;
    public static bool redFlag;

    private void Start()
    {
        blueFlag = true;
        redFlag = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("blueFlag = " + blueFlag);
        Debug.Log("redFlag = " + redFlag);



        if (blueFlag)
        {
            blueFlag = false;
        }
        else
        {
            blueFlag = true;
        }

        if (redFlag)
        {
            redFlag = false;
        }
        else
        {
            redFlag = true;
        }


    }

    private void OnTriggerExit(Collider other)
    {

    }
}
