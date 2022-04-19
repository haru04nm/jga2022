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

                

                //右から左に
                if (areaX[0] < areaX[1])
                {
                    if (nextAreaNum > oldAreaNum)
                    {
                        //右に行く関数
                        RightMove();
                    }

                    if (nextAreaNum < oldAreaNum)
                    {
                        //左に行く関数
                        LeftMove();
                    }
                } 
                
                //左から右に
                if (areaX[0] > areaX[1])
                {
                    if (nextAreaNum < oldAreaNum)
                    {
                        //右に行く関数
                        RightMove();
                    }

                    if (nextAreaNum > oldAreaNum)
                    {
                        //左に行く関数
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
        //移動
        transform.Translate(0.1f, 0,  0);


        //目的地に着いたら止まる
        if (this.transform.position.x >= areaX[nextAreaNum - 1])
        {
            oldAreaNum = nextAreaNum;
            nextAreaNum++;

            //もしnextAreaNumがstageAreaNumを超えたら戻す
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
        //移動
        transform.Translate(-0.1f, 0,  0);

        //目的地に着いたら止まる
        if (this.transform.position.x <= areaX[nextAreaNum - 1])
        {
            oldAreaNum = nextAreaNum;
            nextAreaNum--;

            //もしnextAreaNumが0を超えたら戻す
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
