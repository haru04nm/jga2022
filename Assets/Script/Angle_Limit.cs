using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Angle_Limit : MonoBehaviour
{
    private HingeJoint hingejoint;
    private JointLimits jointlimits;
    private Rigidbody rbody;

    bool stopFlag = false;


    private void Start()
    {
        rbody = GetComponent<Rigidbody>();
        hingejoint = GetComponent<HingeJoint>();
        jointlimits = hingejoint.limits;
    }
    private void Update()
    {
        if(Throw_Rope.moveObjectFlag)
        {
            // �V�t�g��������Ă���A����̊p�x�ɂȂ�܂œ�������
            rbody.isKinematic = false;

            if (this.transform.rotation.z == jointlimits.min)
            {
                stopFlag = true;
            }

        }
        else
        {
            rbody.isKinematic = true;
        }

        // Debug.Log(stopFlag);
    }

    private void FixedUpdate()
    {
        if(stopFlag)
        {
            rbody.isKinematic = true;
        }
    }
}
