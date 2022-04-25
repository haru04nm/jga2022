using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Break_Wall : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Barrele")
        {
            Expload.exploadFlag = true;
            Destroy(this.gameObject);

            Destroy(collision.gameObject);

        }
    }
}
