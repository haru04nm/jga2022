using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorMove : MonoBehaviour
{
    /*
    int areaNum = 1;

    float[] areaY;

    Rigidbody rb;

    GameObject child;

    private void OnCollisionStay(Collision collision)
    {
         child= transform.GetChild(0).gameObject;

        //if (collision.gameObject.tag=="Player")
        if (child.GetComponent<BoxCollider>().isTrigger)
        {
            if (areaNum==1)
            {
                //���֐�
                UpMove();
            }

            if (areaNum==2)
            {
                //����֐�
                DownMove();
            }
        }
    }

    void UpMove()
    {
        
        if (this.transform.position.y<=10.0f)
        {
            Debug.Log("2");

            transform.position = new Vector3(-13, 10.0f, 0.5f);
            //rb.velocity = new Vector3(0, 10.0f, 0.5f);
            //areaNum++;
        }

        
    }

    void DownMove()
    {
        areaNum--;
    }
    */

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
        if (transform.position.y < 34 && floar == 1f && EVflag == true)
        {
            transform.Translate(0, 0.1f, 0);

        }


        if (transform.position.y > 6f && floar == 2f && EVflag == true)
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

}
