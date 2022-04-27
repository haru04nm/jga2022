using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Break_Wall : MonoBehaviour
{
    [SerializeField]
    GameObject explode;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Barrele")
        {
            Expload.exploadFlag = true;
            explode.gameObject.transform.parent = null;
            Destroy(this.gameObject);

            Destroy(collision.gameObject);

        }
    }
}
