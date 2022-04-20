using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorMove : MonoBehaviour
{
    int nextAreaNum = 1;
    int oldAreaNum;

    [SerializeField]
    float[] areaY;

    [SerializeField]
    int stageAreaNum;

    bool isHitFlag = false;

    float deletTime;

    Time time;

    [SerializeField]
    GameObject tobira;

    [SerializeField]
    GameObject saka;

    float limtTime;

    //GameObject child;

    private void Start()
    { 
        saka.SetActive(false);
        tobira.SetActive(false);
    }

    private void FixedUpdate()
    {
        if (isHitFlag)
        {
            deletTime += Time.deltaTime;
            isHitFlag = false;

            if (deletTime >= limtTime)
            {
                tobira.SetActive(true);

                saka.SetActive(false);

                //下から上に
                if (areaY[0] < areaY[1])
                {
                    if (nextAreaNum > oldAreaNum)
                    {
                        //上り関数
                        UpMove();
                    }

                    if (nextAreaNum < oldAreaNum)
                    {
                        //下り関数
                        DownMove();
                    }
                }

                //上から下に
                if (areaY[0] > areaY[1])
                {
                    if (nextAreaNum < oldAreaNum)
                    {
                        //上り関数
                        UpMove();
                    } 
                    
                    if (nextAreaNum > oldAreaNum)
                    {
                        //下り関数
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

            limtTime = 2.5f;

            if (collision.gameObject.tag == "Player" )
            {
                limtTime = 1.0f;
            }
        }
    }

    void UpMove()
    {
        //移動
        transform.Translate(0, 0.1f, 0);
        
        //目的地に着いたら止まる
        if (this.transform.position.y>=areaY[nextAreaNum-1])
        {
            oldAreaNum = nextAreaNum;
            nextAreaNum++;

            //もしnextAreaNumがstageAreaNumを超えたら戻す
            if (nextAreaNum > stageAreaNum)
            {
                nextAreaNum -= 2;
            }
            isHitFlag = false;
            deletTime = 0.0f;
            tobira.SetActive(false);
            saka.SetActive(true);
        }        
    }

    void DownMove()
    { 
        //移動
        transform.Translate(0, -0.1f, 0);

        //目的地に着いたら止まる
        if (this.transform.position.y<=areaY[nextAreaNum-1])
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
            tobira.SetActive(false);
            saka.SetActive(true);
        }
    }
}
