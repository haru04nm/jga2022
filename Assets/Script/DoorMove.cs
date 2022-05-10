using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMove : MonoBehaviour
{
    Switch_Door button;

    float goalPos=0;

    float translate=0;

    // Start is called before the first frame update
    void Start()
    {
        button = GameObject.Find("switch3").GetComponent<Switch_Door>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (button.IsPushFlag)
        {
            if (transform.position.z>=4)
            {
                goalPos = 0.0f;
                translate = -0.05f;
            }

            if (transform.position.z<=0)
            {
                goalPos=4.0f;
                translate = 0.05f;
            }

            kDoorMove(goalPos, translate);  
        }
    }

    void kDoorMove(float g,float z)
    {
        this.transform.Translate(0, 0, z);

        if (transform.position.z==g)
        {
            button.IsPushFlag = false;
            return;
        }
    }
}
