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
    GameObject body;
    RaycastHit hit;

    const int LayerMask = ~(1 << 6);

    public bool LeftFlg
    {
        get { return leftFlag; }
    }

    private void Start()
    {
        rbody = GetComponent<Rigidbody>();
        animator = transform.Find("Mesh Object").gameObject.GetComponent<Animator>();
        body = GameObject.Find("Body").gameObject;
    }

    private void Update()
    {
        //RaycastHit hit;
        groundFlag = Physics.Raycast(transform.position, Vector3.down, 0.1f, LayerMask);


        /*
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 0.1f, LayerMask))
        {
            groundFlag = true;
            //Debug.Log("!! " + hit.collider.name);
            //Debug.DrawRay(transform.position, Vector3.down, Color.yellow);

        }
        */

    }


    private void FixedUpdate()
    {
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
    /*
    private void OnTriggerStay(Collider other)
    {
        groundFlag = true;
    }

    private void OnTriggerExit(Collider other)
    {
        groundFlag = false;
    }
    */
    public void OnMove(InputAction.CallbackContext context)
    {
        // MoveƒAƒNƒVƒ‡ƒ“‚Ì“ü—ÍŽæ“¾
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
