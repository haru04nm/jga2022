using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorMove : MonoBehaviour
{
    [SerializeField]
    int stageAreaNum;

    [SerializeField]
    float[] areaY;
    
    GameObject tobira;

    GameObject saka;
    
    int nextAreaNum = 1;

    int oldAreaNum;

    float deletTime;

    float limtTime;

    bool isHitFlag = false;

    private void Start()
    {
        tobira = GameObject.Find("�o����").gameObject;
        saka= GameObject.Find("��").gameObject;
        
        //1.tobira,2.saka;
        SetActiveSakaTobira(false, false);
    }

    private void FixedUpdate()
    {
        if (isHitFlag)
        {
            deletTime += Time.deltaTime;
            isHitFlag = false;

            if (deletTime >= limtTime)
            {
                //1.tobira[0],2.saka[0];
                SetActiveSakaTobira(true, false);

                //��������
                if (areaY[0] < areaY[1])
                {

                    if (nextAreaNum > oldAreaNum)
                    {
                        //���֐�
                        UpMove();
                    }

                    if (nextAreaNum < oldAreaNum)
                    {
                        //����֐�
                        DownMove();
                    }
                }

                //�ォ�牺��
                if (areaY[0] > areaY[1])
                {
                    if (nextAreaNum < oldAreaNum)
                    {
                        //���֐�
                        UpMove();
                    } 
                    
                    if (nextAreaNum > oldAreaNum)
                    {
                        //����֐�
                        DownMove();
                    }
                } 
            } 
        }       
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Barrele")
        {
            isHitFlag = true;

            if (collision.gameObject.tag == "Barrele")
            {
                limtTime = 2.5f;
            }

            if (collision.gameObject.tag == "Player" )
            {
                limtTime = 1.0f;
            }
        }
    }

    void UpMove()
    { 
        //�ړ�
        transform.Translate(0, 0.1f, 0);
        
        //�ړI�n�ɒ�������~�܂�
        if (this.transform.position.y>=areaY[nextAreaNum-1])
        {
            oldAreaNum = nextAreaNum;
            nextAreaNum++;

            //����nextAreaNum��stageAreaNum�𒴂�����߂�
            if (nextAreaNum > stageAreaNum)
            {
                nextAreaNum -= 2;
            }

            isHitFlag = false;
            deletTime = 0.0f;

            //1.tobira[0],2.saka[0];
            SetActiveSakaTobira(false, true);
        }        
    }

    void DownMove()
    {
        //�ړ�
        transform.Translate(0, -0.1f, 0);

        //�ړI�n�ɒ�������~�܂�
        if (this.transform.position.y<=areaY[nextAreaNum-1])
        {
            oldAreaNum = nextAreaNum;
            nextAreaNum--;

            //����nextAreaNum��0�𒴂�����߂�
            if (nextAreaNum == 0)
            {
                nextAreaNum += 2;
            }

            isHitFlag = false;
            deletTime = 0.0f;

            //1.tobira[0],2.saka[0];
            SetActiveSakaTobira(false, true);
        }
    }

    void SetActiveSakaTobira(bool a,bool b)
    {
        tobira.SetActive(a);
        saka.SetActive(b);
    }
}
