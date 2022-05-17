using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeltConveorMove : MonoBehaviour
{
    
    [SerializeField]
    float[] areaX;

    [SerializeField]
    int areaNum;

    [SerializeField]
    string[] leftOrRightDoor;

    GameObject[] tobira;

    GameObject[] saka;

    int nextAreaNum = 1;

    int oldAreaNum;

    float deletTime;

    float limtTime;
    
    bool isHitFlag=false;

    private void Start()
    {
        tobira= new GameObject[2];
        saka = new GameObject[2];

        tobira[0] = GameObject.Find("左出入口").gameObject;
        tobira[1] = GameObject.Find("右出入口").gameObject;
        saka[0] = GameObject.Find("左坂").gameObject;
        saka[1] = GameObject.Find("右坂").gameObject;

        for (int x = 0; x < 2; x++)
        {
            //1.tobira[0],2.tobira[1],3.saka[0],4.saka[1];
            SetActiveSakaTobira(true, true, false, false);
        }

        if (areaX[0] < areaX[1])
        {
            //1.tobira[0],2.tobira[1],3.saka[0],4.saka[1];
            SetActiveSakaTobira(false, false, false, false); 
            oldAreaNum = -areaNum;
        }

        if (areaX[0] > areaX[1])
        {
            //1.tobira[0],2.tobira[1],3.saka[0],4.saka[1];
            SetActiveSakaTobira(false, false, false, false);
            oldAreaNum = areaNum;
        }

        if (leftOrRightDoor.Length!=areaNum)
        {
            Debug.LogError("数合わせんかい!!");
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
                //1.tobira[0],2.tobira[1],3.saka[0],4.saka[1];
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
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Barrele" || collision.gameObject.tag == "Tama")
        {
            isHitFlag = true;

            limtTime = 2.5f;

            if (collision.gameObject.tag == "Player")
            {
                limtTime = 1.0f;
            }
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        deletTime = 0.0f;
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

            //もしnextAreaNumがstageAreaNumを超えたら戻す
            if (nextAreaNum > areaNum)
            {
                nextAreaNum -= 2;
            }

            if (leftOrRightDoor[nextAreaNum-1] == ("左"))
            {
                //1.tobira[0],2.tobira[1],3.saka[0],4.saka[1];
                SetActiveSakaTobira(false, true, false, true);
            }

            if (leftOrRightDoor[nextAreaNum - 1] == ("右"))
            {
                //1.tobira[0],2.tobira[1],3.saka[0],4.saka[1];
                SetActiveSakaTobira(true, false, true, false);
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

            //もしnextAreaNumが0を超えたら戻す
            if (nextAreaNum == 0)
            {
                nextAreaNum += 2;
            }

            if (leftOrRightDoor[nextAreaNum - 1] ==("左"))
            {
                //1.tobira[0],2.tobira[1],3.saka[0],4.saka[1];
                SetActiveSakaTobira(false, true, false, true);
            }
            
            if (leftOrRightDoor[nextAreaNum - 1] ==("右"))
            {
                //1.tobira[0],2.tobira[1],3.saka[0],4.saka[1];
                SetActiveSakaTobira(true, false, true, false);
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
