using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainLightActive : MonoBehaviour
{
    [SerializeField]
    int barreleNum;

    Barrel[] barrele;

    GameObject mainLight;

    GameObject breakWall;
    // Start is called before the first frame update
    void Start()
    {
        barrele=new Barrel[barreleNum];

        barrele[0] = GameObject.Find("Barrele").GetComponent<Barrel>();

        if (barreleNum != 1)
        {
            for (int i=1;i<barreleNum;i++)
            {
                barrele[i] = GameObject.Find("Barrele ("+i+")").GetComponent<Barrel>();
            }
        }

        mainLight = GameObject.Find("Directional Light").gameObject;

        breakWall = GameObject.Find("Wall_break").gameObject;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        int count = 0;
        for (int i=0;i<barreleNum;i++)
        {
            if (barrele[i].GetLightFlag)
            {
                mainLight.SetActive(false);
                count++;
            }
            
            if(count == 0)
            {
                mainLight.SetActive(true);
            }
        }
        
        if (breakWall==null)
        {
            mainLight.SetActive(true);
        }
    }
}
