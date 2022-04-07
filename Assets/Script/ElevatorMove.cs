using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorMove : MonoBehaviour
{
    int areaNum = 1;

    float[] areaY;

    private void OnCollisionEnter(Collision collision)
    {
        GameObject child = transform.GetChild(0).gameObject;

        //if (collision.gameObject.tag=="Player")
        if (child.GetComponent<BoxCollider>().isTrigger)
        {
            Debug.Log("2");
            if (areaNum==1)
            {
                //ã‚èŠÖ”
                UpMove();
            }

            if (areaNum==2)
            {
                //‰º‚èŠÖ”
                DownMove();
            }
        }
    }

    void UpMove()
    {
        if (this.transform.position.y>=10.0f)
        {
            //this.transform.
            areaNum++;
        }

        
    }

    void DownMove()
    {
        areaNum--;
    }
}
