using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch_Open : MonoBehaviour
{
    [SerializeField]
    float doorNum;

    GameObject red;
    GameObject blue;

    private void Start()
    {
        red= GameObject.Find("red").gameObject;
        blue= GameObject.Find("blue").gameObject;
    }

    private void Update()
    {

        if (Switch_Door.redFlag)
        {
            red.gameObject.SetActive(true);
            Debug.Log("!!");
        }
        else
        {
            red.gameObject.SetActive(false);
            Debug.Log("??");
        }

        if (Switch_Door.blueFlag)
        {
            blue.gameObject.SetActive(true);
        }
        else
        {
            blue.gameObject.SetActive(false);
        }
    }
}
