using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch_Door : MonoBehaviour
{
    public static bool redFlag;
    public static bool blueFlag;

    private void Start()
    {
        blueFlag = false;
        redFlag = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(redFlag)
        {
            redFlag = false;
        }
        if(redFlag==false)
        {
            redFlag = true;
        }

        if(blueFlag)
        {
            blueFlag = false;
        }
        if(blueFlag==false)
        {
            blueFlag = true;
        }
    }
}
