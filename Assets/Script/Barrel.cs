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
        lightFlag = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //if(oldPosX != transform.position.x)
        if(rbody.velocity.sqrMagnitude > 0.5)
        {
            //spotLight@ON
            lightFlag = true;
            spotLight.SetActive(true);
            //spotLight.transform.position = new Vector3(transform.position.x,transform.position.y+5,spotLight.transform.position.z);
            //spotLight.transform.rotation = Quaternion.Euler(-55, 0, 0) * this.transform.rotation;

            barreleSoundTime += Time.deltaTime;
            if((barreleSoundTime >= 0.2f && rbody.velocity.x > 0.8) || (barreleSoundTime >= 0.2f && rbody.velocity.x < -0.8))
            {
                audioSource.PlayOneShot(barreleSound);
                barreleSoundTime = 0;
            }
        }
        else
        {
            //spotLight@OFF
            lightFlag = false;
            spotLight.SetActive(false);
        }
        spotLight.transform.position = new Vector3(transform.position.x, transform.position.y + 5, spotLight.transform.position.z);
        spotLight.transform.rotation = Quaternion.Euler(125, 0, 0) * Quaternion.Inverse(this.transform.rotation);

        oldPosX = this.transform.position.x;
    }

    public  bool IsLightFlag
    {
        get
        {
            return lightFlag;
        }

        set
        {
            lightFlag = value;
        }
    }
}
