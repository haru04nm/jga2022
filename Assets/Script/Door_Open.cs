using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Open : MonoBehaviour
{
    [SerializeField]
    float doorNum;

    private void FixedUpdate()
    {
        
        if (doorNum == 1)
        {
            if (Switch_Door.blueFlag == false)
            {
                this.gameObject.SetActive(true);
            }
            else
            {
                this.gameObject.SetActive(false);
            }
        }
        
        if(doorNum == 2)
        {
            if (Switch_Door.redFlag == false)
            {
                this.gameObject.SetActive(true);
            }
            else
            {
                this.gameObject.SetActive(false);
            }

        }
        
    }
}
