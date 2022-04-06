using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitGround : MonoBehaviour
{
    bool isHitFlag = false;

    GameObject tobira;

    private void Start()
    {
        tobira=GameObject.Find("�o����").gameObject;
    }

    private void FixedUpdate()
    {
        if (IsHitFlag)
        {
            tobira.SetActive(true);
        }

        if (!IsHitFlag)
        {
            tobira.SetActive(false);
        }
    }

    //���̓����蔻��
    private void OnCollisionEnter(Collision collision)
    {
        isHitFlag = true;
    }

    public bool IsHitFlag
    {
        get
        {
            return isHitFlag;
        }

        set
        {
            isHitFlag = value;
        }
    }
}
