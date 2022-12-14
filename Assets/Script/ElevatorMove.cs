using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorMove : MonoBehaviour
{
    [SerializeField]
    int stageAreaNum;

    [SerializeField]
    float[] areaY;

    Rigidbody rb;
    
    GameObject tobira;

    GameObject saka;
    
    int nextAreaNum = 1;

    int oldAreaNum;

    float deletTime;

    float limtTime;

    bool isHitFlag = false;

    bool movingFlag=false;

    private void Start()
    {
        rb = GameObject.Find(this.gameObject.name).GetComponent<Rigidbody>();

        tobira = GameObject.Find(this.gameObject.name+"/出入口").gameObject;
        saka= GameObject.Find(this.gameObject.name + "/坂").gameObject;

        //this.rb.isKinematic = true;

        //1.tobira,2.saka;
        SetActiveSakaTobira(false, false);
    }

    private void FixedUpdate()
    {
        if (isHitFlag)
        {
            deletTime += Time.deltaTime;

            if (deletTime >= limtTime)
            {
                //1.tobira[0],2.saka[0];
                SetActiveSakaTobira(true, false);

                this.rb.GetComponent<Rigidbody>().constraints &= ~RigidbodyConstraints.FreezePositionY;
                //this.rb.isKinematic = false;

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

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Barrele" || collision.gameObject.tag =="Tama")
        {
            isHitFlag = true;

            if(!movingFlag)
            {
                deletTime = 0.0f;
            }

            limtTime = 2.5f;

            if (collision.gameObject.tag == "Player" )
            {
                limtTime = 1.0f;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Barrele" || other.gameObject.tag == "Tama")
        {
            isHitFlag = false;

            if (!movingFlag)
            {
                deletTime = 0.0f;
            }
        }
    }

    void UpMove()
    {
        if (this.transform.position.y + float.Epsilon < areaY[nextAreaNum])
        {
            this.rb.velocity = new Vector3(0, 8f, 0);
            movingFlag = true;
        }
        else
        {
            Vector3 pos = this.transform.position;
            pos.y = areaY[nextAreaNum];
            this.transform.position = pos;

            movingFlag = false;

            oldAreaNum = nextAreaNum;
            nextAreaNum++;

            //もしnextAreaNumがareaY.Lengthを超えたら戻す
            if (nextAreaNum == areaY.Length)
            {
                nextAreaNum = areaY.Length - 2;
            }

            isHitFlag = false;
            deletTime = 0.0f;

            this.rb.velocity = new Vector3(0, 0, 0);
            this.rb.GetComponent<Rigidbody>().constraints |= RigidbodyConstraints.FreezePositionY;
            //this.rb.isKinematic = true;

            //1.tobira[0],2.saka[0];
            SetActiveSakaTobira(false, true);
        }
    }

    void DownMove()
    {
        //移動
        if (this.transform.position.y - float.Epsilon > areaY[nextAreaNum])
        {
            this.rb.velocity = new Vector3(0, -4f, 0);
            movingFlag = true;
        }
        else
        {
            Vector3 pos = this.transform.position;
            pos.y = areaY[nextAreaNum];
            this.transform.position = pos;

            movingFlag = false;

            oldAreaNum = nextAreaNum;
            nextAreaNum--;

            //もしnextAreaNumがー１を超えたら戻す
            if (nextAreaNum == -1)
            {
                nextAreaNum = 1;
            }

            isHitFlag = false;
            deletTime = 0.0f;

            this.rb.velocity = new Vector3(0, 0, 0);
            this.rb.GetComponent<Rigidbody>().constraints |= RigidbodyConstraints.FreezePositionY;
            //this.rb.isKinematic = true;

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
