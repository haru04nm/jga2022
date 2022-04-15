using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel_Collision : MonoBehaviour
{
    [SerializeField]
    GameObject other_barrel;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject == other_barrel)
        {
            Destroy(this.gameObject);
            Destroy(other_barrel);
        }
    }
}
