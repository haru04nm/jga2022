using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch_Setactive : MonoBehaviour
{
    [SerializeField]
    GameObject[] _switch; 

    void Start()
    {

    }

    void FixedUpdate()
    {
        for (int x=0;x<_switch.Length;x++)
        {
            if(_switch[x].GetComponent<Switch_Door>().IsSwitchActive)
            {
                for (int y=0;y<_switch.Length;y++)
                {
                    if (x != y)
                    {
                        _switch[y].SetActive(true);
                    }
                    else
                    {
                        _switch[y].SetActive(false);
                    }
                }
            }
        }
    }
}
