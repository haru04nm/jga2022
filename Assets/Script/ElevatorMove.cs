using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorMove : MonoBehaviour
{
    int areaNum = 1;

    float[] areaY;

    private void OnCollisionEnter(Collision collision)
    {
        

        if (collision.gameObject.tag=="Player")
        {
            Debug.Log("2");
            if (areaNum==1)
            {
                //上り関数
                UpMove();
            }

            if (areaNum==2)
            {
                //下り関数
                DownMove();
            }
        }
    }

    void UpMove()
    {
        //if

        areaNum++;
    }

    void DownMove()
    {
        areaNum--;
    }
}
