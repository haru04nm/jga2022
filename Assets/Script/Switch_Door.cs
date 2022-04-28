using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch_Door : MonoBehaviour
{
    static bool redFlag;
    static bool blueFlag;

    static bool thornFlag;

    [SerializeField]
    GameObject[] door;

    [SerializeField]
    int doorNum;

    GameObject[] thorn;

    [SerializeField]
    int thornNum;

    bool switchActive;


    private void Start()
    {
        blueFlag = false;
        redFlag = true;
        switchActive = false;
        thornFlag = true;

        if (doorNum!=0)
        {
            for (int i=0;i<doorNum;i++)
            {
                door[i].gameObject.SetActive(redFlag);

                if (i%2==1)
                {
                    door[i].gameObject.SetActive(blueFlag);
                }
            }
        }

        if (thornNum!=0)
        {
            thorn = new GameObject[thornNum];

            for (int i=0;i<thornNum;i++)
            {
                thorn[i] = GameObject.Find("Toge ("+(i+1)+")").gameObject;
            }
        
            foreach(var i in thorn)
            {
                i.SetActive(thornFlag);
            }
        } 
    }

    private void OnTriggerEnter(Collider other)
    {
        switchActive = true;

        redFlag = !redFlag;
        blueFlag = !blueFlag;
        thornFlag = !thornFlag;

        if (doorNum != 0)
        {
            for (int i = 0; i < doorNum; i++)
            {
                door[i].gameObject.SetActive(redFlag);

                if (i % 2 == 1)
                {
                    door[i].gameObject.SetActive(blueFlag);
                }
            }

            
        }  
        
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
    
}
