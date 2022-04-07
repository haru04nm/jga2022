using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorMove : MonoBehaviour
{
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
                //è„ÇËä÷êî
                UpMove();
            }

            if (areaNum==2)
            {
                //â∫ÇËä÷êî
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
}
