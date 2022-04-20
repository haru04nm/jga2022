using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Push_Brrele : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        HingeJoint hj = GetComponent<HingeJoint>();
        hj.useMotor = false;
    }
}