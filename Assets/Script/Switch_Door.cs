using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch_Door : MonoBehaviour
{
    GameObject[] thorn;

    int thornNum;

    bool switchActive;

    bool plshFlag;

    bool thornFlag;

    //‰¹
    AudioSource audioSource;

    [SerializeField]
    AudioClip switchSound;
   

    private void Start()
    {
        thornNum = GameObject.Find("OtherIndex").GetComponent<OtherIndex>().IsTogeIndex;

        audioSource = GetComponent<AudioSource>();

        switchActive = false;
        thornFlag = true;
        plshFlag = false;
   
        if (thornNum!=0)
        {
            thorn = new GameObject[thornNum];

            thorn[0] = GameObject.Find("Toge").gameObject;

            for (int i=1;i<thornNum;i++)
            {
                thorn[i] = GameObject.Find("Toge ("+i+")").gameObject;
            }
        
            foreach(var i in thorn)
            {
                i.SetActive(thornFlag);
            }
        } 
    }

    private void OnTriggerEnter(Collider other)
    {
        audioSource.PlayOneShot(switchSound);

        switchActive = true;

        plshFlag = true;

        thornFlag = !thornFlag;
        if (thornNum != 0)
        {
            foreach (var i in thorn)
            {
                i.SetActive(false);
            }
        }
    }
    public bool IsSwitchActive
    {
        get
        {
            return switchActive;
        }
        set
        {
            switchActive = value;
        }
    }

    public bool IsPushFlag
    {
        get
        {
            return plshFlag;
        }

        set
        {
            plshFlag = value;
        }
    }
}
