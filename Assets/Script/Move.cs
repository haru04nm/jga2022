using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Move : MonoBehaviour
{
    float speed = 10f;
    float jumppower = 10f;
    bool leftFlag = false;
    bool jumpFlag = false;
    bool groundFlag = false;

    Rigidbody rbody;
    private Animator animator;
    private Vector2 _moveInputValue;


    [SerializeField]
    Stage_Clear flag;


    public bool LeftFlg
    {
        get { return leftFlag; }
    }

    private void Start()
    {
        rbody = GetComponent<Rigidbody>();
        animator = transform.Find("Mesh Object").gameObject.GetComponent<Animator>();
        /*
        // Input Actionインスタンス生成
        _action = new Action();

        // Actionイベント登録
        _action.Player.Move.started += OnMove;
        _action.Player.Move.performed += OnMove;
        _action.Player.Move.canceled += OnMove;

        _action.Enable();
        */
    }

    private void Update()
    {
        
        if (Stage_Clear.clearFlag == false)
        {
            /*
            vx = 0;

            if (action.Player.Move.triggered)
            {
                vx = speed;
                leftFlag = false;
                this.transform.rotation = Quaternion.Euler(0.0f, ry, 0.0f);
            }
            if (action.Player.Move.triggered)
            {
                vx = -speed;
                leftFlag = true;
                this.transform.rotation = Quaternion.Euler(0.0f, ly, 0.0f);
            }
            */

            /*
            if (_action.Player.Jump.triggered && groundFlag)
            {
                if (pushFlag == false)
                {
                    jumpFlag = true;
                    pushFlag = true;
                    groundFlag = false;
                    animator.SetBool("JumpFlg", true);
                }
            }
            else
            {
                pushFlag = false;
                animator.SetBool("JumpFlg", false);
            }
            */
        }

    }


    private void FixedUpdate()
    {
        if (flag.IsClearFlag)
        {
            animator.speed = 0;
            return;
        }

        rbody.velocity = new Vector3(_moveInputValue.x * speed, rbody.velocity.y, 0);

        animator.SetFloat("Move", rbody.velocity.magnitude);

        

        if (jumpFlag)
        {
            jumpFlag = false;
            rbody.AddForce(new Vector3(0, jumppower), ForceMode.Impulse);
            animator.SetBool("JumpFlg", true);
        }

        if (groundFlag)
        {
            animator.SetBool("JumpFlg", false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        groundFlag = true;
    }

    private void OnTriggerExit(Collider other)
    {
        groundFlag = false;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (flag.IsClearFlag) return;


        // Moveアクションの入力取得
        _moveInputValue = context.ReadValue<Vector2>();

        if (_moveInputValue.sqrMagnitude == 0.0f) return;

        bool postFlg = leftFlag;
        leftFlag = false;
        if (_moveInputValue.x < 0)
        {
            leftFlag = true;
            
        }

        if(postFlg != leftFlag)
        {
            transform.rotation = Quaternion.Euler(0, leftFlag ? -90 : 90, 0);
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started && groundFlag/* && !pushFlag*/)
        {
            jumpFlag = true;
            //pushFlag = true;
            groundFlag = false;
        }
    }
}
