using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch_Door : MonoBehaviour
{
    GameObject[] thorn;

    [SerializeField]
    int thornNum;

    bool switchActive;

    bool plshFlag;

    bool thornFlag;

    //��
    AudioSource audioSource;

    [SerializeField]
    AudioClip switchSound;
   

    private void Start()
    {
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
        Debug.Log("!");
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
