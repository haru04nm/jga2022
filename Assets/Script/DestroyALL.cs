using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyALL : MonoBehaviour
{
    GameObject other;

    Break_Test[] taru;

    GameObject[] toge;

    GameObject[] explode;

    int barreleIndex;

    int thornIndex;

    private void Start()
    {
        barreleIndex = GameObject.Find("OtherIndex").GetComponent<OtherIndex>().IsBarreleIndex;
        thornIndex = GameObject.Find("OtherIndex").GetComponent<OtherIndex>().IsTogeIndex;


        taru = new Break_Test[barreleIndex];
        explode = new GameObject[barreleIndex];

        if (barreleIndex != 0)
        { 
            for (int i=0;i<barreleIndex;i++)
            {
                taru[i] = GameObject.Find("Barrele").GetComponent<Break_Test>();

                if (i != 0)
                {
                    taru[i] = GameObject.Find("Barrele (" + i + ")").GetComponent<Break_Test>();

                }

                explode[i] = taru[i].transform.Find("explode").gameObject;
                explode[i].GetComponent<Exploder>().enabled = false;
                explode[i].GetComponent<ParticleComponent>().enabled = false;
                explode[i].GetComponent<PseudoVolumetricComponent>().enabled = false;
            }
        }

        if (thornIndex != 0)
        {
            toge = new GameObject[thornIndex];

            toge[0] = GameObject.Find("Toge").gameObject;

            for (int i = 1; i < thornIndex; i++)
            {
                toge[i] = GameObject.Find("Toge (" + i + ")").gameObject;
            }
        }  
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        for (int i = 0; i < barreleIndex;i++)
        {
            if (taru[i].IsDestroyFlag)
            {
                taru[i].IsDestroyFlag = false;
                other = taru[i].GetOther;

                explode[i].gameObject.transform.parent = null;


                explode[i].GetComponent<Exploder>().enabled = true;
                explode[i].GetComponent<ParticleComponent>().enabled = true;
                explode[i].GetComponent<PseudoVolumetricComponent>().enabled = true;

                Expload.exploadFlag = true;

                if (other.gameObject.tag == "Barrele")
                {
                    other.gameObject.GetComponent<Barrel>().IsLightFlag = false; 
                }

                if (other.gameObject.tag != "Trap")
                {
                    Destroy(other.gameObject);
                }

                Destroy(taru[i].gameObject);
            }
        }
    }
}
