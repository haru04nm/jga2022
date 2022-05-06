using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Barrel : MonoBehaviour
{
    GameObject spotLight;

    float oldPosX;
    float barreleSoundTime;


    bool lightFlag =false;

    [SerializeField]
    AudioClip barreleSound;

    Rigidbody rbody;
    AudioSource audioSource;

    private void Start()
    {
        rbody = GetComponent<Rigidbody>();
        spotLight = this.transform.GetChild(1).gameObject;
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //spotLight@OFF
        spotLight.SetActive(false);

        lightFlag = false;

        if(oldPosX != transform.position.x)
        {
            //spotLight@ON
            spotLight.SetActive(true);
            spotLight.transform.position = new Vector3(transform.position.x,transform.position.y+5,spotLight.transform.position.z);

            barreleSoundTime += Time.deltaTime;
            if((barreleSoundTime >= 0.2f && rbody.velocity.x > 0.8) || (barreleSoundTime >= 0.2f && rbody.velocity.x < -0.8))
            {
                audioSource.PlayOneShot(barreleSound);
                barreleSoundTime = 0;
            }

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
