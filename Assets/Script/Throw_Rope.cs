using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Throw_Rope : MonoBehaviour
{
    private float spring = 10.0f;
    private float distance;
    float waitTime;

    public static bool pushFlag = false;
    bool lineFlag = false;
    public static bool moveObjectFlag = false;
    private bool rightShoulderFlag;

    [SerializeField]
    GameObject head;

    [SerializeField]
    GameObject RightHand;


    Rigidbody rbody;
    GameObject Aim;
    private Animator animator;
    private LineRenderer lineRenderer;
    private SpringJoint springJoint;

    RaycastHit hit;
    Ray ray;
    Vector3 anchorTarget;
    GameObject hitObject;

    GameObject sphere;

    [SerializeField]
    Stage_Clear flag;

    [SerializeField]
    AudioClip throwSound;

    AudioSource audioSource;

    bool hitKinematic;

    private void Start()
    {
        animator = transform.Find("Mesh Object").gameObject.GetComponent<Animator>();
        rbody = this.GetComponent<Rigidbody>();
        Aim = transform.Find("AimLine").gameObject;
        sphere = GameObject.Find("ロープのかぎ爪");
        hitObject = null;
        audioSource = GetComponent<AudioSource>();
        sphere.SetActive(false);
        this.springJoint = GetComponent<SpringJoint>();
        this.springJoint.spring = 0;
        this.lineRenderer = null;
        lineFlag = false;

    }

    private void Update()
    {
        Vector3 dir = Aim.GetComponent<LineMove>().GetDirection().normalized;

        if (Physics.Raycast(head.transform.position, dir, out hit, 9f))
        {
            Debug.DrawRay(head.transform.position, dir * hit.distance, Color.yellow);

            if (rightShoulderFlag && hitObject == null)
            {
                waitTime += Time.deltaTime;

                if(waitTime >= 0.25)
                {
                    pushFlag = true;
                    BoxRay.adhesionFlag = true;
                    anchorTarget = dir * hit.distance;
                    distance = Vector3.Distance(head.transform.position, hit.point);    // 距離計算
                    Aim.SetActive(false);

                    // 投げるSE再生
                    audioSource.PlayOneShot(throwSound);

                    hitObject = hit.collider.gameObject;

                    // Rigidbodyがついているオブジェクトに投げた時の処理
                    if (hitObject.GetComponent<Rigidbody>() != null)
                    {
                        hitKinematic = hitObject.GetComponent<Rigidbody>().isKinematic;

                        hitObject.GetComponent<Rigidbody>().isKinematic = false;
                    }
                    waitTime = 0;
                }

                // 投げるアニメーション
                animator.SetBool("ThrowFlag", true);
                animator.SetBool("FastThrowFlag", true);
            }
        }

        // ボタンが押されている間、ラインレンダラーを更新し続ける
        if (lineFlag && hitObject != null)
        {
            this.lineRenderer.SetPosition(0, RightHand.transform.position);
            this.lineRenderer.SetPosition(1, hitObject.transform.TransformPoint(this.springJoint.connectedAnchor));
        }

        if (rightShoulderFlag == false && hitObject)
        {
            // アニメーション関連
            animator.SetBool("ThrowFlag", false);
            animator.SetBool("FastThrowFlag", false);

            pushFlag = false;
            BoxRay.adhesionFlag = false;
            Aim.SetActive(true);

            if(hitObject.GetComponent<Rigidbody>() != null)
            {
                hitObject.GetComponent<Rigidbody>().isKinematic = hitKinematic;
            } 
        }
    }

    private void FixedUpdate()
    {
        if (pushFlag)
        {
            lineFlag = true;
            moveObjectFlag = true;
            sphere.SetActive(true);

            if (this.springJoint.spring == 0)
            {
                // スプリングジョイントの設定
                {
                    //this.springJoint = this.gameObject.AddComponent<SpringJoint>();
                    //this.springJoint.autoConfigureConnectedAnchor = false;
                    //this.springJoint.anchor = new Vector3(0, 2.52f, 0);
                    //this.springJoint.spring = this.spring;
                    //this.springJoint.enableCollision = true;
                    this.springJoint.spring = this.spring;
                    this.springJoint.maxDistance = distance;
                    //this.springJoint.breakForce = 75;　

                    if (hitObject != null)
                    {
                        this.springJoint.connectedBody = hitObject.GetComponent<Rigidbody>();
                        this.springJoint.connectedAnchor = hitObject.transform.InverseTransformPoint(head.transform.position + anchorTarget);
                    }
                }

                // ラインレンダラーの設定
                {
                    this.lineRenderer = this.gameObject.AddComponent<LineRenderer>();
                    this.lineRenderer.startWidth = 0.3f;
                    this.lineRenderer.endWidth = 0.3f;
                    this.GetComponent<LineRenderer>().material.color = new Color32(148, 78, 48, 1);
                }
            }
        }
        else
        {
            // アニメーション関連
            animator.SetBool("ThrowFlag", false);
            animator.SetBool("FastThrowFlag", false);


            lineFlag = false;
            BoxRay.adhesionFlag = false;
            hitObject = null;
            moveObjectFlag = false;
            //Destroy(this.springJoint);
            Destroy(this.lineRenderer);
            //this.springJoint = null;
            this.springJoint.spring = 0;
            this.lineRenderer = null;
            sphere.SetActive(false);
        }
        
        if (hitObject != null)
        {
            sphere.transform.position = hitObject.transform.TransformPoint(this.springJoint.connectedAnchor);
        }
        else
        {
            lineFlag = false;
            Aim.SetActive(true);
            sphere.SetActive(false);
            //Destroy(this.springJoint);
            Destroy(this.lineRenderer);
            //this.springJoint = null;
            this.springJoint.spring = 0;
            this.lineRenderer = null;
        }
    }

    
    public void OnThrow(InputAction.CallbackContext context)
    {
        if (flag.IsClearFlag) return;

        if (context.phase == InputActionPhase.Performed)
        {
            rightShoulderFlag = true;
        }
        if (context.phase == InputActionPhase.Canceled)
        {
            rightShoulderFlag = false;
        }
    }


    private void OnDestroy()
    {
        lineFlag = false;
        //Aim.SetActive(true);
        //sphere.SetActive(false);
        //Destroy(this.springJoint);
        Destroy(this.lineRenderer);
        //this.springJoint = null;
        //this.springJoint.spring = 0;
        this.lineRenderer = null;
        hitObject = null;
    }
}