using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Domino_Sound : MonoBehaviour
{
    float soundNum;

    AudioSource audioSource;

    [SerializeField]
    AudioClip dominoSound;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(soundNum >= 1)
        {
            audioSource.PlayOneShot(dominoSound);

        }

        soundNum++;
    }
}
