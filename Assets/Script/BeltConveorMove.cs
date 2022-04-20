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
            SetActiveSakaTobira(true, true, false, false); 
        }

        if (areaX[0] < areaX[1])
        {
            SetActiveSakaTobira(true, false, false, false);
        }
        
        if (areaX[0] > areaX[1])
        {
            SetActiveSakaTobira(false, true, false, false);
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
                SetActiveSakaTobira(true, true, false, false);

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
        transform.Translate(0.1f, 0, 0);

        //目的地に着いたら止まる
        if (this.transform.position.x >= areaX[nextAreaNum - 1])
        {
            oldAreaNum = nextAreaNum;
            nextAreaNum++;

            SetActiveSakaTobira(true, false, true, false);

            //もしnextAreaNumがstageAreaNumを超えたら戻す
            if (nextAreaNum > areaNum)
            {
                nextAreaNum -= areaNum-1;

                if (areaX[0] > areaX[1])
                {
                    SetActiveSakaTobira(false,true,false,true);
                }
            }

            isHitFlag = false;
            deletTime = 0.0f;
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

            SetActiveSakaTobira(false, true, false, true);

            //もしnextAreaNumが0を超えたら戻す
            if (nextAreaNum == 0)
            {
                nextAreaNum += areaNum-1;

                if (areaX[0] < areaX[1])
                {
                    SetActiveSakaTobira(true, false, true, false);
                }
            }

            isHitFlag = false;
            deletTime = 0.0f;
        }
    }


    void SetActiveSakaTobira(bool a,bool b,bool c,bool d)
    {
        tobira[0].SetActive(a);
        tobira[1].SetActive(b);
        saka[0].SetActive(c);
        saka[1].SetActive(d);
    }
}
