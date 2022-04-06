using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Expload : MonoBehaviour
{
    public static bool exploadFlag;
    bool destroyFlag;

    float destroyTime;
    public AudioClip expload;
    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        exploadFlag = false;
        destroyFlag = false;

        GetComponent<Exploder>().enabled = false;
        GetComponent<ParticleComponent>().enabled = false;
        GetComponent<PseudoVolumetricComponent>().enabled = false;
    }

    private void Update()
    {
        if(destroyFlag)
        {
            destroyTime += Time.deltaTime; 
            if (destroyTime >= 2)
            {
                Destroy(this.gameObject);
            }

        }
    }

    private void FixedUpdate()
    {
        if (exploadFlag)
        {
            GetComponent<Exploder>().enabled = true;
            GetComponent<ParticleComponent>().enabled = true;
            GetComponent<PseudoVolumetricComponent>().enabled = true;
            destroyFlag = true;
        }

    }
    

}
