using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelMove : MonoBehaviour
{
    Rigidbody rbody;

    int move;
    const int moveNum = 2;

    bool turnFlag;

    ObjectMove barrelMoveObj;

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody>();

        barrelMoveObj = GameObject.Find("objectMove").GetComponent<ObjectMove>();

        turnFlag = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (barrelMoveObj.IsBarrelMoveFlag)
        {
            rbody.isKinematic = false;

            move = turnFlag ? -moveNum : moveNum;

            rbody.velocity = new Vector3(move, 0, 0);

            if (!turnFlag)
            {
                if (this.transform.position.x >= 13f)
                {
                    turnFlag = true;
                }
            }
            else 
            {
                if (this.transform.position.x <= -13f)
                {
                    rbody.isKinematic = true;

                    turnFlag = false;
                    barrelMoveObj.IsBarrelMoveFlag = false;
                    barrelMoveObj.IsRandomFlag = false;
                }
            }
            
        }
        
    }
}
