using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyALL : MonoBehaviour
{
    GameObject other;

    Break_Test taru;

    private void Start()
    {
        taru = GameObject.Find("Barrele").GetComponent<Break_Test>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (taru.IsDestroyFlag)
        {
            taru.IsDestroyFlag = false;
            other = taru.GetOther;

            if (other.gameObject.tag == "Barrele")
            {
                other.gameObject.GetComponent<Barrel>().IsLightFlag = false; 
            }

            Destroy(other.gameObject);
        }
    }
}
