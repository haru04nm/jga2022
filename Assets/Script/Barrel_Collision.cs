using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel_Collision : MonoBehaviour
{
    [SerializeField]
    GameObject other_barrele;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject == other_barrele)
        {
            

            Destroy(this.gameObject);
            Destroy(other_barrele);
        }
    }
}
