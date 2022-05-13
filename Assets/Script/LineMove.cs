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

        // �E�����Ă���Ƃ�
        if (upFlag && angleCount <= 50 && angleCount >= -20 && move.LeftFlg == false)
        {
            angleCount++;
            // RotateAround(���S�̏ꏊ,��,��]�p�x)
            this.transform.RotateAround(center.transform.position, Vector3.forward, angle * 0.025f);
            
        }
        if (downFlag && angleCount >= -20 && angleCount <= 50 && move.LeftFlg == false)
        {
            angleCount--;
            this.transform.RotateAround(center.transform.position, Vector3.back, angle * 0.025f);
        }

        // �������Ă���Ƃ�
        if (upFlag && angleCount <= 50 && angleCount >= -20 && move.LeftFlg)
        {
            angleCount++;
            // RotateAround(���S�̏ꏊ,��,��]�p�x)
            this.transform.RotateAround(center.transform.position, Vector3.back, angle * 0.025f);
        }
        if (downFlag && angleCount >= -20 && angleCount <= 50 && move.LeftFlg)
        {
            angleCount--;
            this.transform.RotateAround(center.transform.position, Vector3.forward, angle * 0.025f);
        }

        

        


    }

    public void OnLineMove(InputAction.CallbackContext context)
    {
        if (flag.IsClearFlag)
        { 
            return; 
        }


        _moveInputValue = context.ReadValue<Vector2>();


        // angleCount���w��͈̔͂̏ꍇ�̂݃L�[���͂��󂯕t����

        if (_moveInputValue.y > 0)
        {
            upFlag = true;
        }

        if(_moveInputValue.y < 0)
        {
            downFlag = true;
        }

        if (_moveInputValue.y==0)
        {
            upFlag = false;
            downFlag = false;
        }
    }


}
