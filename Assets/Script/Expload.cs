using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Expload : MonoBehaviour
{
    public static bool exploadFlag;

    [SerializeField]
    AudioClip expload;

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
            audioSource.PlayOneShot(expload);

            exploadFlag = false;
        }

    }
    

}
