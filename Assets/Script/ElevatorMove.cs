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
        tobira = GameObject.Find("出入口").gameObject;
        saka= GameObject.Find("坂").gameObject;
        
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

            //1.tobira[0],2.saka[0];
            SetActiveSakaTobira(false, true);
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
