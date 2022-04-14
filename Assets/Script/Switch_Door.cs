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

    bool switchActive;


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
            switchActive = true;
        }
        else
        {
            redFlag = true;
            switchActive = false;
        }

        if (blueFlag)
        {
            blueFlag = false;
            switchActive = true;
        }
        else
        {
            blueFlag = true;
            switchActive = false;
        }

    }

    private void FixedUpdate()
    {
        if (redFlag)
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

    public bool IsSwitchActive
    {
        get
        {
            return switchActive;
        }
        set
        {
            switchActive = value;
        }
    }
    
}
