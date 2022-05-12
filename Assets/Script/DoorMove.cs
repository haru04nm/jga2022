using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMove : MonoBehaviour
{
    Switch_Door button;

    AudioSource audioSource;

    [SerializeField]
    AudioClip doorSound;

    //float goalPos=0;

    //float translate = 0;
    //float totalPos = 0.0f;

    const float ActivePosZ = 0.0f;
    const float DeactivePosZ = 4.0f;
    const float OperationTime = 1.0f;
    float time = 0.0f;
    float startZ;
    float goalZ;

    // Start is called before the first frame update
    void Start()
    {
        button = GameObject.Find("switch3").GetComponent<Switch_Door>();
        audioSource = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        if(time > 0.0f)
        {
            time -= Time.deltaTime;
            if(time < 0.0f)
            {
                time = 0.0f;
                button.IsPushFlag = false;
            }

            Vector3 pos = this.transform.position;
            pos.z = Mathf.Lerp(startZ, goalZ, (OperationTime - time) / OperationTime);
            this.transform.position = pos;
        }
        else
        {
            if (button.IsPushFlag)
            {
                audioSource.PlayOneShot(doorSound);

                time = OperationTime;
                startZ = this.transform.position.z;
                if (this.transform.position.z == ActivePosZ)
                {
                    goalZ = DeactivePosZ;
                }
                else
                {
                    goalZ = ActivePosZ;
                }
            }
        }
    }

    /*
    // Update is called once per frame
    void FixedUpdate()
    {
        if (button.IsPushFlag)
        {
            if (transform.position.z >= 4)
            {
                goalPos = 0.0f;
                translate = -0.05f;
            }

            if (transform.position.z <= 0)
            {
                goalPos = 4.0f;
                translate = 0.05f;
            }

            Vector3.Lerp();
            kDoorMove(goalPos, translate);  
        }
    }

    void kDoorMove(float g,float z)
    {
        this.transform.Translate(0, 0, z);
        totalPos += z;

        if (Mathf.Abs(totalPos)>=4.0f)
        {
            button.IsPushFlag = false;
            totalPos = 0.0f;
        }
    }
    */
}
