using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch_Open : MonoBehaviour
{
    [SerializeField]
    float doorNum;

    private void Update()
    {

        if(doorNum == 1)
        {
            if (Switch_Door.redFlag)
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
            if(Switch_Door.blueFlag)
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
