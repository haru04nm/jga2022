using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMove : MonoBehaviour
{
    int randomNum;

    public static bool playerMoveFlag;
    public static bool barrelMoveFlag;
    public static bool randomFlag;

    // Start is called before the first frame update
    void Start()
    {
        playerMoveFlag = false;
        barrelMoveFlag = false;
        randomFlag = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!randomFlag)
        {
            randomNum = Random.Range(0, 2);

            if (randomNum == 0 && !playerMoveFlag && !barrelMoveFlag)
            {
                playerMoveFlag = true;
                barrelMoveFlag = false;
            }
            else if (randomNum == 1 && !playerMoveFlag && !barrelMoveFlag)
            {
                playerMoveFlag = false;
                barrelMoveFlag = true;
            }

            randomFlag = true;

        }
    }

    public bool IsPlayerMoveFlag
    {
        get
        {
            return playerMoveFlag;
        }

        set
        {
            playerMoveFlag = value;
        }
    }

    public bool IsBarrelMoveFlag
    {
        get
        {
            return barrelMoveFlag;
        }

        set
        {
            barrelMoveFlag = value;
        }
    }

    public bool IsRandomFlag
    {
        get
        {
            return randomFlag;
        }

        set
        {
            randomFlag = value;
        }
    }
}
