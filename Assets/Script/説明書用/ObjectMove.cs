using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMove : MonoBehaviour
{
    int randomNum;

    public static bool playerMoveFlag;
    public static bool barrelMoveFlag;

    // Start is called before the first frame update
    void Start()
    {
        playerMoveFlag = false;
        barrelMoveFlag = false;

        randomNum = Random.Range(0, 2);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //randomNum = Random.Range(0, 2);

        Debug.Log(randomNum);
        Debug.Log("playerMoveFlag : " + playerMoveFlag);
        Debug.Log("barrelMoveFlag : " + barrelMoveFlag);

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

    /*
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
    */
}
