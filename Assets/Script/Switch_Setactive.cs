using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch_SetActive : MonoBehaviour
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
                _switch[x].GetComponent<Switch_Door>().IsSwitchActive = false;

                for (int y=0;y<_switch.Length;y++)
                {
                    if (x != y)
                    {
                        // ‚½‚½‚«‹N‚±‚·
                        _switch[y].SetActive(true);
                    }
                    else
                    {
                        // “¥‚ñ‚¾‚Ì‚ÅQ‚©‚¹‚é
                        _switch[y].SetActive(false);
                    }
                }
            }
        }
    }
}
