using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Break_Wall : MonoBehaviour
{
    [SerializeField]
    GameObject targetObjectName;



    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject == targetObjectName)
        {

            Expload.exploadFlag = true;
            Destroy(this.gameObject);

            Destroy(targetObjectName);

        }
    }
}
