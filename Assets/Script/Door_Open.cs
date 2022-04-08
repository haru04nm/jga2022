using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Open : MonoBehaviour
{
    GameObject Blue;
    GameObject Red;

    private void Start()
    {
        Blue = transform.Find("blue").gameObject;
        Red = transform.Find("red").gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (Blue.activeSelf == true)
        {
            Blue.SetActive(false);
        }
        if(Blue.activeSelf==false)
        {
            Blue.SetActive(true);
        }

        if(Red.activeSelf==true)
        {
            Red.SetActive(false);
        }
        if(Red.activeSelf==false)
        {
            Red.SetActive(true);
        }
    }
}
