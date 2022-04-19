using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Break_Test : MonoBehaviour
{
    [SerializeField]
    GameObject explode;

    private void Start()
    {
        explode.GetComponent<Exploder>().enabled = false;
        explode.GetComponent<ParticleComponent>().enabled = false;
        explode.GetComponent<PseudoVolumetricComponent>().enabled = false;

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Barrele")
        {
            explode.gameObject.transform.parent = null;

            explode.GetComponent<Exploder>().enabled = true;
            explode.GetComponent<ParticleComponent>().enabled = true;
            explode.GetComponent<PseudoVolumetricComponent>().enabled = true;


            Destroy(this.gameObject);

            Destroy(collision.gameObject);

        }
    }
}
