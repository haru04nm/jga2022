using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hinge_Sound : MonoBehaviour
{
    float hingeSoundTime;

    Rigidbody rbody;
    AudioSource audioSource;


    [SerializeField]
    AudioClip hinge;


    private void Start()
    {
        rbody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        
        hingeSoundTime += Time.deltaTime;

        if ((rbody.velocity.x > 0.2f && hingeSoundTime >= 0.2) || (rbody.velocity.x < -0.2f && hingeSoundTime >= 0.2))
        {
            audioSource.PlayOneShot(hinge);
            hingeSoundTime = 0;
        }
    }
}
