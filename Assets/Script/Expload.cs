using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Expload : MonoBehaviour
{
    public static bool exploadFlag;

    public AudioClip expload;
    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        exploadFlag = false;
        GetComponent<Exploder>().enabled = false;
        GetComponent<ParticleComponent>().enabled = false;
        GetComponent<PseudoVolumetricComponent>().enabled = false;
    }


    private void FixedUpdate()
    {
        if (exploadFlag)
        {
            //audioSource.PlayOneShot(expload);
            GetComponent<Exploder>().enabled = true;
            GetComponent<ParticleComponent>().enabled = true;
            GetComponent<PseudoVolumetricComponent>().enabled = true;
        }

    }
    

}
