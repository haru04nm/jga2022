using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch_Open : MonoBehaviour
{
    [SerializeField]
    float doorNum;

    [SerializeField]
    GameObject Switch1;
    [SerializeField]
    GameObject Switch2;

    private void Start()
    {
        Switch1 = GameObject.Find("red").gameObject;
        Switch2 = GameObject.Find("blue").gameObject;
    }

    private void Update()
    {

        if (Switch_Door.redFlag)
        {
            Switch1.gameObject.SetActive(true);
        }
        else
        {
            Switch1.gameObject.SetActive(false);
        }
        if (Switch_Door.blueFlag)
        {
            Switch2.gameObject.SetActive(true);
        }
        else
        {
            Switch2.gameObject.SetActive(false);
        }
    }
}
