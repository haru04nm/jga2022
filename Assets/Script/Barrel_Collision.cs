using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel_Collision : MonoBehaviour
{
    [SerializeField]
    GameObject other_barrele;

    GameObject explode;
    private void Start()
    {
        explode = GameObject.Find("explode").gameObject;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject == other_barrele)
        {
            explode.gameObject.transform.parent = null;
            Expload.exploadFlag = true;

            Destroy(this.gameObject);
            Destroy(other_barrele);
        }
    }
}
