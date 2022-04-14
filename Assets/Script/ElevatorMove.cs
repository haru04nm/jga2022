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

    //GameObject child;

    private void Start()
    { 
        saka.SetActive(true);
        tobira.SetActive(false);
    }

    private void FixedUpdate()
    {
        if (isHitFlag)
        {
            deletTime += Time.deltaTime;

            if (deletTime>=2.5f)
            {
                tobira.SetActive(true);

                saka.SetActive(false);
                
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
            else
            {
                isHitFlag = false;
            }
        }
    }

    private void OnTriggerStay(Collider collision)
    {
        //child= transform.GetChild(0).gameObject;

        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Barrele")
        //if (child.GetComponent<BoxCollider>().isTrigger)
        {
            isHitFlag = true;
        }
    }

    void UpMove()
    {
        transform.Translate(0, 0.1f, 0);
        
        if (this.transform.position.y>=areaY[nextAreaNum-1])
        {
            oldAreaNum = nextAreaNum;
            nextAreaNum++;
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
        transform.Translate(0, -0.1f, 0);

        if (this.transform.position.y<=areaY[nextAreaNum-1])
        {
            oldAreaNum = nextAreaNum;
            nextAreaNum--;
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


    /*
    private bool EVflag;
    private float floar;
    // Start is called before the first frame update
    void Start()
    {
        floar = 1f;
        EVflag = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < 10.0f && floar == 1f && EVflag == true)
        {
            transform.Translate(0, 0.1f, 0);

        }


        if (transform.position.y > 1.5f && floar == 2f && EVflag == true)
        {
            transform.Translate(0, -0.1f, 0);
        }




    }
    private void OnTriggerEnter(Collider other)//エレベーターの中に入ったら
    {

        EVflag = true;


    }
    private void OnTriggerExit(Collider other)//エレベーターから出たら
    {
        if (floar == 1f && EVflag == true)
        {
            floar = 2f;
            EVflag = false;
        }
        if (floar == 2f && EVflag == true)
        {
            floar = 1f;
            EVflag = false;
        }
    }
    */

}
