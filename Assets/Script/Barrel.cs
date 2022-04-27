using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Barrel : MonoBehaviour
{
    GameObject spotLight;

    float oldPosX;

    bool lightFlag=false; 

    private void Start()
    {
        spotLight = this.transform.GetChild(1).gameObject;
    }

    // Update is called once per frame
    void FixedUpdate()
    { 
        //spotLightÅ@OFF
        spotLight.SetActive(false);

        lightFlag = false;

        if(oldPosX != transform.position.x)
        {
            //spotLightÅ@ON
            spotLight.SetActive(true);
            spotLight.transform.position = new Vector3(transform.position.x,spotLight.transform.position.y,spotLight.transform.position.z);

            lightFlag = true;
        }

        oldPosX = this.transform.position.x;
    }

    public  bool GetLightFlag
    {
        get
        {
            return lightFlag;
        }
    }
}
