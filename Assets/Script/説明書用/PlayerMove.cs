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

    ObjectMove playerMoveObj;

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody>();
        animator = transform.Find("Mesh Object").gameObject.GetComponent<Animator>();
        body = GameObject.Find("Body").gameObject;

        playerMoveObj = GameObject.Find("objectMove").GetComponent<ObjectMove>();

        turnFlag = false;

    }

    private void FixedUpdate()
    {
        if (playerMoveObj.IsPlayerMoveFlag)
        {
            rbody.isKinematic = false;
            animator.speed = 1;

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
                    rbody.isKinematic = true;
                    animator.speed = 0;

                    turnFlag = false;
                    playerMoveObj.IsPlayerMoveFlag = false;
                    playerMoveObj.IsRandomFlag = false;
                }
            }
        }
    }
}
