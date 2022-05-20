using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Break_Test : MonoBehaviour
{
    GameObject explode;

    GameObject other;

    bool destroyFlag = false;

    private void Start()
    {
        explode = GameObject.Find("explode").gameObject;
        explode.GetComponent<Exploder>().enabled = false;
        explode.GetComponent<ParticleComponent>().enabled = false;
        explode.GetComponent<PseudoVolumetricComponent>().enabled = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        destroyFlag = false;
        if (collision.gameObject.tag == "Barrele" || collision.gameObject.tag == "Trap" || collision.gameObject.tag == "Wall")
        {
            /*
            explode.gameObject.transform.parent = null;

            explode.GetComponent<Exploder>().enabled = true;
            explode.GetComponent<ParticleComponent>().enabled = true;
            explode.GetComponent<PseudoVolumetricComponent>().enabled = true;
            */

            destroyFlag = true;

            other = collision.gameObject;
        }
    }

    public bool IsDestroyFlag
    {
        get
        {
            return destroyFlag;
        }

        set
        {
            destroyFlag = value;
        }
    }

    public GameObject GetOther
    {
        get
        {
            return other;
        }
    }
}
