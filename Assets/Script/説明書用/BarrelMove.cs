using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelMove : MonoBehaviour
{
    Rigidbody rbody;

    int move;
    const int moveNum = 2;

    bool turnFlag;

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody>();

        turnFlag = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(this.transform.position.x >= -14f && this.transform.position.x <= 14f)
        {
            move = turnFlag ? -moveNum : moveNum;

            rbody.velocity = new Vector3(move, 0, 0);

            if(!turnFlag)
            {
                if(this.transform.position.x >= 13f)
                {
                    turnFlag = true;
                }
            }
            else
            {
                if (this.transform.position.x <= -13f)
                {
                    turnFlag = false;
                }
            }
        }
    }
}
