using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeltConveorMove : MonoBehaviour
{
    int nextAreaNum = 1;
    int oldAreaNum;

    [SerializeField]
    float[] areaX;

    [SerializeField]
    int areaNum;

    bool isHitFlag=false;

    float deletTime;

    Time time;

    [SerializeField]
    GameObject[] tobira;

    [SerializeField]
    GameObject[] saka;

    float limtTime;

    private void Start()
    {
        for (int x=0; x<2; x++)
        {
            saka[x].SetActive(false);
            
        }

        if (areaX[0] < areaX[1])
        {
            tobira[0].SetActive(false);
        }
        
        if (areaX[0] > areaX[1])
        {
            tobira[1].SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        if (isHitFlag)
        {
            deletTime += Time.deltaTime;
            isHitFlag = false;

            if (deletTime >= limtTime)
            {
                for (int i=0;i<2;i++)
                {
                    tobira[i].SetActive(true);

                    saka[i].SetActive(false);
                }

                

                //�E���獶��
                if (areaX[0] < areaX[1])
                {
                    if (nextAreaNum > oldAreaNum)
                    {
                        //�E�ɍs���֐�
                        RightMove();
                    }

                    if (nextAreaNum < oldAreaNum)
                    {
                        //���ɍs���֐�
                        LeftMove();
                    }
                } 
                
                //������E��
                if (areaX[0] > areaX[1])
                {
                    if (nextAreaNum < oldAreaNum)
                    {
                        //�E�ɍs���֐�
                        RightMove();
                    }

                    if (nextAreaNum > oldAreaNum)
                    {
                        //���ɍs���֐�
                        LeftMove();
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

            limtTime = 2.5f;

            if (collision.gameObject.tag == "Player")
            {
                limtTime = 1.0f;
            }
        }
    }

    void RightMove()
    {
        //�ړ�
        transform.Translate(0.1f, 0,  0);


        //�ړI�n�ɒ�������~�܂�
        if (this.transform.position.x >= areaX[nextAreaNum - 1])
        {
            oldAreaNum = nextAreaNum;
            nextAreaNum++;

            //����nextAreaNum��stageAreaNum�𒴂�����߂�
            if (nextAreaNum > areaNum)
            {
                nextAreaNum -= 2;
            }
            isHitFlag = false;
            deletTime = 0.0f;
            tobira[0].SetActive(false);
            saka[0].SetActive(true);
        }
    }

    void LeftMove()
    {
        //�ړ�
        transform.Translate(-0.1f, 0,  0);

        //�ړI�n�ɒ�������~�܂�
        if (this.transform.position.x <= areaX[nextAreaNum - 1])
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
            tobira[1].SetActive(false);
            saka[1].SetActive(true);
        }
    }
}
