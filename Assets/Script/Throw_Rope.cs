using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Throw_Rope : MonoBehaviour
{
    private float spring = 10.0f;
    private float distance;

    public static bool pushFlag = false;
    bool lineFlag = false;
    private bool rightShoulderFlag;


    [SerializeField]
    GameObject head;

    [SerializeField]
    GameObject RightHand;

    GameObject beforeObject;

    Rigidbody rbody;
    GameObject Aim;
    private Animator animator;
    private LineRenderer lineRenderer;
    private SpringJoint springJoint;

    RaycastHit hit;
    Ray ray;
    Vector3 anchorTarget;
    GameObject hitObject;
    //private Action _action;
 

    private void Start()
    {
        animator = transform.Find("Mesh Object").gameObject.GetComponent<Animator>();
        rbody = this.GetComponent<Rigidbody>();
        Aim = transform.Find("AimLine").gameObject;
        hitObject = null;

    }

    private void Update()
    {

        Vector3 dir = Aim.GetComponent<LineMove>().GetDirection().normalized;
        //Debug.Log(dir);

        if (Physics.Raycast(head.transform.position, dir, out hit, 9f))
        {
            Debug.DrawRay(head.transform.position, dir * hit.distance, Color.yellow);

            if (rightShoulderFlag)
            {
                //animator.SetBool("ThrowFlag", true);
                pushFlag = true;
                anchorTarget = dir * hit.distance;
                distance = Vector3.Distance(head.transform.position, hit.point);    // 距離計算
                Aim.SetActive(false);

                hitObject = hit.collider.gameObject;
                hitObject.GetComponent<Rigidbody>().isKinematic = false;
            }
        }

        // ボタンを押されている間だけラインレンダラーの始点を更新し続ける
        if (lineFlag)
        {
            this.lineRenderer.SetPosition(0, RightHand.transform.position);
        }

        if (rightShoulderFlag == false && hitObject)
        {
            //animator.SetBool("ThrowFlag", false);

            pushFlag = false;
            Aim.SetActive(true);
            hitObject.GetComponent<Rigidbody>().isKinematic = true;
            hitObject = null;
        }
        
    }

    private void FixedUpdate()
    {
        if (pushFlag)
        {

            lineFlag = true;

            if (this.springJoint == null)
            {
                // スプリングジョイントの設定
                {
                    this.springJoint = this.gameObject.AddComponent<SpringJoint>();
                    this.springJoint.autoConfigureConnectedAnchor = false;
                    this.springJoint.anchor = new Vector3(0, 2.52f, 0);
                    this.springJoint.spring = this.spring;
                    this.springJoint.enableCollision = true;
                    this.springJoint.maxDistance = distance;
                    this.springJoint.connectedBody = hitObject.GetComponent<Rigidbody>();
                    this.springJoint.connectedAnchor = hitObject.transform.InverseTransformPoint(head.transform.position + anchorTarget);
                }

                // ラインレンダラーの設定
                {
                    this.lineRenderer = this.gameObject.AddComponent<LineRenderer>();
                    this.lineRenderer.startWidth = 0.3f;
                    this.lineRenderer.endWidth = 0.3f;
                    GetComponent<LineRenderer>().material.color = new Color32(148, 78, 48, 1);
                    this.lineRenderer.SetPosition(1, hitObject.transform.TransformPoint(this.springJoint.connectedAnchor));
                }
            }

            
        }
        else
        {
            lineFlag = false;
            Destroy(this.springJoint);
            Destroy(this.lineRenderer);
            this.springJoint = null;
        }
    }

    
    public void OnThrow(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            rightShoulderFlag = true;
            animator.SetBool("ThrowFlag", true);

        }
        if (context.phase == InputActionPhase.Canceled)
        {
            rightShoulderFlag = false;
            animator.SetBool("ThrowFlag", false);

        }
    }
    

}