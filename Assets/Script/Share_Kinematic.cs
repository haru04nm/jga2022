using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Share_Kinematic : MonoBehaviour
{
    [SerializeField]
    GameObject ShareObject;

    private void Update()
    {
        if(ShareObject.GetComponent<Rigidbody>().isKinematic)
        {
            this.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        }
        else
        {
            this.gameObject.GetComponent<Rigidbody>().isKinematic = false;

        }
    }
}
