using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody rbody;
    private Animator animator;
    GameObject body;

    int move;
    const int moveNum = 2;

    bool turnFlag;

    bool playerMoveFlag = false;

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody>();
        animator = transform.Find("Mesh Object").gameObject.GetComponent<Animator>();
        body = GameObject.Find("Body").gameObject;

        turnFlag = false;
    }

    private void FixedUpdate()
    {
        Debug.Log("IsPlayerMoveFlag : " + IsPlayerMoveFlag);

        if(IsPlayerMoveFlag)
        {
            move = turnFlag ? -moveNum : moveNum;

            transform.rotation = Quaternion.Euler(0, turnFlag ? -90 : 90, 0);

            rbody.velocity = new Vector3(move, 0, 0);

            animator.SetFloat("Move", rbody.velocity.magnitude);

            if(!turnFlag)
            {
                if (this.transform.position.x >= 13f)
                {
                    turnFlag = true;
                }
            }
            else
            {
                if(this.transform.position.x <= 13f)
                {
                    turnFlag = false;
                    playerMoveFlag = false;
                }
            }
        }

        /*
        if(this.transform.position.x <= -14f)
        {
            playerMoveFlag = false;
        }
        */

        /*
        move = turnFlag ? -moveNum : moveNum;

        transform.rotation = Quaternion.Euler(0, turnFlag ? -90 : 90, 0);

        rbody.velocity = new Vector3(move, 0, 0);

        animator.SetFloat("Move", rbody.velocity.magnitude);

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
                turnFlag = false;
            }
        }
        */
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
}
