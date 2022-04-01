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
    float angle = 60;
    bool upFlag;
    bool downFlag;
    bool upLFlag;
    bool DownLFlag;
    bool maxFlag;
    bool minFlag;

    private Vector2 _moveInputValue;
    

    public Vector3 GetDirection()
    {
        Vector3 dir = this.transform.position - center.transform.position;
        dir.z = 0.0f;
        //Debug.Log("this:"+this.transform.position+" cen:"+center.transform.position);
        return (dir);
    }

    private void Update()
    {

        // �E�����Ă���Ƃ�
        if ((upFlag && angleCount <= 300 && angleCount >= -200) || (minFlag && upFlag))
        {
            angleCount++;
            // RotateAround(���S�̏ꏊ,��,��]�p�x)
            this.transform.RotateAround(center.transform.position, Vector3.forward, angle * Time.deltaTime);
        }
        if ((downFlag && angleCount >= -200 && angleCount <=300) || (maxFlag && downFlag))
        {
            angleCount--;
            this.transform.RotateAround(center.transform.position, Vector3.back, angle * Time.deltaTime);
        }

        // �������Ă���Ƃ�
        if ((upLFlag && angleCount <= 300 && angleCount >= -200) || (minFlag && upLFlag))
        {
            angleCount++;
            // RotateAround(���S�̏ꏊ,��,��]�p�x)
            this.transform.RotateAround(center.transform.position, Vector3.back, angle * Time.deltaTime);
        }
        if ((DownLFlag && angleCount >= -200 && angleCount <= 300) || (maxFlag && DownLFlag))
        {
            angleCount--;
            this.transform.RotateAround(center.transform.position, Vector3.forward, angle * Time.deltaTime);
        }


        if (angleCount >= 300)
        {
            maxFlag = true;
        }
        else
        {
            maxFlag = false;
        }
        if(angleCount<=-200)
        {
            minFlag = true;
        }
        else
        {
            minFlag = false;
        }


    }

    public void OnLineMove(InputAction.CallbackContext context)
    {
        _moveInputValue = context.ReadValue<Vector2>();


        // angleCount���w��͈̔͂̏ꍇ�̂݃L�[���͂��󂯕t����
        if (move.LeftFlg == false)
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
        if (move.LeftFlg)
        {
            if (_moveInputValue.y > 0)
            {
                upLFlag = true;
            }
        }
        if (move.LeftFlg)
        {
            if (_moveInputValue.y < 0)
            {
                DownLFlag = true;
            }
        }
        
        if(_moveInputValue.y==0)
        {
            upFlag = false;
            downFlag = false;
            upLFlag = false;
            DownLFlag=false;
        }
    }


}
