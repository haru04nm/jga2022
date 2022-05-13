using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class LineMove : MonoBehaviour
{
    [SerializeField]
    GameObject center;

    [SerializeField]
    Move move;

    int angleCount;
    //float angle = 60;
    const float Angle = 105;

    bool upFlag;
    bool downFlag;
    bool downLFlag;
    bool upLFlag;
    bool maxFlag;
    bool minFlag;
    

    
    private Vector2 _moveInputValue;

    [SerializeField]
    Stage_Clear flag;



    public Vector3 GetDirection()
    {
        Vector3 dir = this.transform.position - center.transform.position;
        dir.z = 0.0f;
        //Debug.Log("this:"+this.transform.position+" cen:"+center.transform.position);
        return (dir);
    }

    private void FixedUpdate()
    {
        float ang = 0.0f;
        if (upFlag && angleCount < 50)
        {
            angleCount++;
            ang = Angle / 70;
        }
        if (downFlag && angleCount > -20)
        {
            angleCount--;
            ang = -Angle / 70;
        }
        if(ang != 0.0f)
        {
            this.transform.RotateAround(center.transform.position, move.LeftFlg ? Vector3.back : Vector3.forward, ang);
        }

        /*
        // �E�����Ă���Ƃ�
        if (upFlag && angleCount <= 50 && angleCount >= -20 || minFlag && upFlag)
        {
            angleCount++;
            // RotateAround(���S�̏ꏊ,��,��]�p�x)
            this.transform.RotateAround(center.transform.position, Vector3.forward, angle * 0.025f);
            
        }
        if (downFlag && angleCount >= -20 && angleCount <= 50 || maxFlag&& downFlag)
        {
            angleCount--;
            this.transform.RotateAround(center.transform.position, Vector3.back, angle * 0.025f);
        }

        // �������Ă���Ƃ�
        if (upLFlag && angleCount <= 50 && angleCount >= -20  || minFlag && upLFlag)
        {
            angleCount++;
            // RotateAround(���S�̏ꏊ,��,��]�p�x)
            this.transform.RotateAround(center.transform.position, Vector3.back, angle * 0.025f);
        }
        if (downLFlag && angleCount >= -20 && angleCount <= 50 || maxFlag && downLFlag)
        {
            angleCount--;
            this.transform.RotateAround(center.transform.position, Vector3.forward, angle * 0.025f);
        }

        if(angleCount >= 30)
        {
            maxFlag = true;
        }
        else
        {
            maxFlag = false;
        }

        if(angleCount <= -20)
        {
            minFlag = true;
        }
        else
        {
            minFlag = false;
        }
        */



        
    }

    public void OnLineMove(InputAction.CallbackContext context)
    {
        if (flag.IsClearFlag)
        { 
            return; 
        }


        _moveInputValue = context.ReadValue<Vector2>();


        // angleCount���w��͈̔͂̏ꍇ�̂݃L�[���͂��󂯕t����

        upFlag = false;
        downFlag = false;
        if (_moveInputValue.y > 0)
        {
            upFlag = true;
        }
        else if (_moveInputValue.y < 0)
        {
            downFlag = true;
        }
        /*
        if(move.LeftFlg == false)
        {
            if (_moveInputValue.y > 0)
            {
                upFlag = true;
            }
        }
        if (move.LeftFlg == false)
        {
            if (_moveInputValue.y < 0)
            {
                downFlag = true;
            }
        }
        if(move.LeftFlg)
        {
            if(_moveInputValue.y > 0)
            {
                upLFlag = true;
            }
        }

        if(move.LeftFlg)
        {
            if (_moveInputValue.y < 0)
            {
                downLFlag = true;
            }
        }

        if (_moveInputValue.y==0)
        {
            upFlag = false;
            downFlag = false;
            upLFlag = false;
            downLFlag = false;
        }
        */
    }


}
