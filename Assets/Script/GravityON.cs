using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityON : MonoBehaviour
{

    Rigidbody rbody;

    private void Start()
    {
        rbody = this.GetComponent<Rigidbody>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (Throw_Rope.pushFlag==false)
        {
            this.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
            this.gameObject.GetComponent<Rigidbody>().isKinematic = false;
    }

}
