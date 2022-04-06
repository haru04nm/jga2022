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

    private void Update()
    {
        if(GetComponent<Rigidbody>().isKinematic)
        {
            GetComponent<Rigidbody>().isKinematic = false;
        }
    }

}
