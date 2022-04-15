using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch_Door : MonoBehaviour
{
    static bool redFlag;
    static bool blueFlag;

    [SerializeField]
    GameObject door1;

    [SerializeField]
    GameObject door2;

    bool switchActive;


    private void Start()
    {
        blueFlag = false;
        redFlag = true;
        switchActive = false;
        door1.gameObject.SetActive(redFlag);
        door2.gameObject.SetActive(blueFlag);

    }



    private void OnTriggerEnter(Collider other)
    {
        switchActive = true;

        redFlag = !redFlag;
        blueFlag = !blueFlag;

        door1.gameObject.SetActive(redFlag);
        door2.gameObject.SetActive(blueFlag);
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
