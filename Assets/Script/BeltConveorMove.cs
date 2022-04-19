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
    GameObject tobira;

    [SerializeField]
    GameObject saka;

    float limtTime;

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

            if (deletTime >= limtTime)
            {
                tobira.SetActive(true);

                saka.SetActive(false);

                if (nextAreaNum > oldAreaNum)
                {
                    //�ړI�ɍs���֐�
                    UpMove();
                }

                if (nextAreaNum < oldAreaNum)
                {
                    //�����ʒu�ɖ߂��čs���֐�
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

    void UpMove()
    {
        transform.Translate(0, 0.1f, 0);

        if (this.transform.position.y >= areaX[nextAreaNum - 1])
        {
            oldAreaNum = nextAreaNum;
            nextAreaNum++;
            if (nextAreaNum > areaNum)
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

        if (this.transform.position.y <= areaX[nextAreaNum - 1])
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
}