using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_ObjectSound : MonoBehaviour
{

    Rigidbody rbody;

    AudioSource audioSource;


    [SerializeField]
    AudioClip pullSound;


    private void Start()
    {
        rbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if(rbody.velocity.x != 0)
        {
            audioSource.PlayOneShot(pullSound);
        }
    }
}
