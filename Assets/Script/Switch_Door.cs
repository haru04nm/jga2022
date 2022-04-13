using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch_Door : MonoBehaviour
{
    public static bool redFlag;
    public static bool blueFlag;

    [SerializeField]
    GameObject door1;
    [SerializeField]
    GameObject door2;

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



        if(redFlag)
        {
            door1.gameObject.SetActive(true);
        }
        else
        {
            door1.gameObject.SetActive(false);
        }
        if (blueFlag)
        {
            door2.gameObject.SetActive(true);
        }
        else
        {
            door2.gameObject.SetActive(false);
        }


    }

}
