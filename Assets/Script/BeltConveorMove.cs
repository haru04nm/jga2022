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

    Rigidbody rb;

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
        rb = GameObject.Find("Belt Conveyor").GetComponent<Rigidbody>();

        for (int x = 0; x < 2; x++)
        {
            //1.tobira[0],2.tobira[1],3.saka[0],4.saka[1];
            SetActiveSakaTobira(true, true, false, false);
        }

        if (areaX[0] < areaX[1])
        {
            //1.tobira[0],2.tobira[1],3.saka[0],4.saka[1];
            SetActiveSakaTobira(false, false, false, false);
        }

        if (areaX[0] > areaX[1])
        {
            //1.tobira[0],2.tobira[1],3.saka[0],4.saka[1];
            SetActiveSakaTobira(false, false, false, false);
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

            if (deletTime >= limtTime)
            {
                //1.tobira[0],2.tobira[1],3.saka[0],4.saka[1];
                SetActiveSakaTobira(true, true, false, false);

                rb.GetComponent<Rigidbody>().constraints &= ~RigidbodyConstraints.FreezePositionX;

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

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Barrele" || collision.gameObject.tag == "Tama")
        {
            deletTime = 0.0f;
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
        if (this.transform.position.x + float.Epsilon < areaX[nextAreaNum])
        {
            rb.velocity = new Vector3(8f,0, 0);
        }
        else
        {
            Vector3 pos = this.transform.position;
            pos.x = areaX[nextAreaNum];
            this.transform.position = pos;

            oldAreaNum = nextAreaNum;
            nextAreaNum++;

            //もしnextAreaNumがareaY.Lengthを超えたら戻す
            if (nextAreaNum == areaX.Length)
            {
                nextAreaNum = areaX.Length - 2;
            }

            isHitFlag = false;
            deletTime = 0.0f;

            rb.velocity = new Vector3(0, 0, 0);
            rb.GetComponent<Rigidbody>().constraints |= RigidbodyConstraints.FreezePositionX;

            if (leftOrRightDoor[nextAreaNum] == ("左"))
            {
                //1.tobira[0],2.tobira[1],3.saka[0],4.saka[1];
                SetActiveSakaTobira(false, true, false, true);
            }

            if (leftOrRightDoor[nextAreaNum] == ("右"))
            {
                //1.tobira[0],2.tobira[1],3.saka[0],4.saka[1];
                SetActiveSakaTobira(true, false, true, false);
            }
        }
    }

    void LeftMove()
    {
        //移動
        if (this.transform.position.x - float.Epsilon > areaX[nextAreaNum])
        {
            rb.velocity = new Vector3(-8f,0,0);
        }
        else
        {
            Vector3 pos = this.transform.position;
            pos.x = areaX[nextAreaNum];
            this.transform.position = pos;

            oldAreaNum = nextAreaNum;
            nextAreaNum--;

            //もしnextAreaNumがー１を超えたら戻す
            if (nextAreaNum == -1)
            {
                nextAreaNum = 1;
            }

            isHitFlag = false;
            deletTime = 0.0f;

            rb.velocity = new Vector3(0, 0, 0);
            rb.GetComponent<Rigidbody>().constraints |= RigidbodyConstraints.FreezePositionX;

            if (leftOrRightDoor[nextAreaNum] == ("左"))
            {
                //1.tobira[0],2.tobira[1],3.saka[0],4.saka[1];
                SetActiveSakaTobira(false, true, false, true);
            }

            if (leftOrRightDoor[nextAreaNum] == ("右"))
            {
                //1.tobira[0],2.tobira[1],3.saka[0],4.saka[1];
                SetActiveSakaTobira(true, false, true, false);
            }
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
