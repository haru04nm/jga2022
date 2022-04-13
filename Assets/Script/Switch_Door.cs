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

    //[SerializeField]
    //GameObject door3;

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
            //door3.gameObject.SetActive(true);

        }
        else
        {
            door2.gameObject.SetActive(false);
            //door3.gameObject.SetActive(false);

        }

    }
    // スイッチ押したら他のスイッチ押すまで押せなくする
}
