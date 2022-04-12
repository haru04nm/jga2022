using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorMove : MonoBehaviour
{
    int areaNum = 1;

    float[] areaY;

    bool isHitFlag = false;

    float deletTime;

    Time time;

    GameObject tobira;

    //GameObject child;

    private void Start()
    {
        tobira = GameObject.Find("�o����").gameObject;
        tobira.SetActive(false);
    }

    private void FixedUpdate()
    {
        if (isHitFlag)
        {
            deletTime += Time.deltaTime;

            if (deletTime>=1.0f)
            {
                tobira.SetActive(true);
                if (areaNum == 1)
                {
                    //���֐�
                    UpMove();
                }

                if (areaNum == 2)
                {
                    //����֐�
                    DownMove();
                }
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        //child= transform.GetChild(0).gameObject;

        if (collision.gameObject.tag == "Player")
        //if (child.GetComponent<BoxCollider>().isTrigger)
        {
            isHitFlag = true;
        }
    }

    void UpMove()
    {
        transform.Translate(0, 0.1f, 0);
        
        if (this.transform.position.y>=10.0f)
        {
            areaNum++;
            isHitFlag = false;
            deletTime = 0.0f;
            tobira.SetActive(false);
        }        
    }

    void DownMove()
    { 
        transform.Translate(0, -0.1f, 0);

        if (this.transform.position.y<=1.5f)
        {
            areaNum--;
            isHitFlag = false;
            deletTime = 0.0f;
            tobira.SetActive(false);
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
    private void OnTriggerEnter(Collider other)//�G���x�[�^�[�̒��ɓ�������
    {

        EVflag = true;


    }
    private void OnTriggerExit(Collider other)//�G���x�[�^�[����o����
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
