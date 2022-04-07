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
        //if

        areaNum++;
    }

    void DownMove()
    {
        areaNum--;
    }
}
