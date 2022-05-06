using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMove : MonoBehaviour
{
    int randomNum;

    bool playerMoveFlag;
    bool barrelMoveFlag;

    // Start is called before the first frame update
    void Start()
    {
        playerMoveFlag = false;
        barrelMoveFlag = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        randomNum = Random.Range(0, 1);

        if (randomNum == 0 && !playerMoveFlag && !barrelMoveFlag)
        {
            playerMoveFlag = true;
            barrelMoveFlag = false;
        }
        else if(randomNum == 1 && !playerMoveFlag && !barrelMoveFlag)
        {
            playerMoveFlag = false;
            barrelMoveFlag = true;
        }
    }
}
