using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Move : MonoBehaviour
{
    float speed = 10f;

    [SerializeField]
    float jumppower;
    float oldPosX;
    float runSound;

    bool leftFlag = false;
    bool jumpFlag = false;
    bool groundFlag = false;
    bool oldGroundFlag = false;
    bool jumpSoundFlag;

    Rigidbody rbody;
    private Animator animator;
    private Vector2 _moveInputValue;
    GameObject body;
    RaycastHit hit;

    [SerializeField]
    AudioClip run;

    [SerializeField]
    AudioClip landing;

    [SerializeField]
    AudioClip jump;

    AudioSource audioSource;


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
        audioSource = GetComponent<AudioSource>();


        
        if (this.gameObject.transform.rotation.y >= -90)
        {
            leftFlag = true;
        }
    }

    private void FixedUpdate()
    {
        Debug.Log(leftFlag);

        // 下方向にレイをとばす
        groundFlag = Physics.Raycast(transform.position, Vector3.down, 0.3f, LayerMask);


        rbody.velocity = new Vector3(_moveInputValue.x * speed, rbody.velocity.y, 0);

        animator.SetFloat("Move", rbody.velocity.magnitude);


        if (rbody.velocity.x < 0 || rbody.velocity.x > 0)
        {
            runSound += Time.deltaTime;
            // 一定間隔ごとに足音を鳴らす
            if (runSound >= 0.4 && groundFlag)
            {
                
                audioSource.PlayOneShot(run);
                runSound = 0;
            }
        }

        
        if (jumpFlag)
        {
            jumpFlag = false;
            rbody.AddForce(new Vector3(0, jumppower), ForceMode.Impulse);
            animator.SetBool("JumpFlg", true);
            
            jumpSoundFlag = true;
        }

        if (groundFlag)
        {

            if(jumpSoundFlag)
            {
                
                audioSource.PlayOneShot(jump);

                jumpSoundFlag = false;
            }

            // 着地した瞬間にSE鳴らす
            if (oldGroundFlag!=groundFlag)
            {
                // 音を出す
                audioSource.PlayOneShot(landing);
                animator.SetBool("JumpFlg", false);
            }
        }
        oldGroundFlag = groundFlag;
    }
    
    public void OnMove(InputAction.CallbackContext context)
    {
        // Moveアクションの入力取得
        _moveInputValue = context.ReadValue<Vector2>();

        if (_moveInputValue.sqrMagnitude == 0.0f) return;


        bool postFlg = leftFlag;
        leftFlag = false;
        if (_moveInputValue.x < 0)
        {
            leftFlag = true;
        }

        // 入力された方向に向きを変える
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
        }
    }
}
