using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_ObjectSound : MonoBehaviour
{
    float pullSoundTime;

    Rigidbody rbody;

    AudioSource audioSource;

    [SerializeField]
    AudioClip pullSound;


    private void Start()
    {
        rbody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();

    }

    private void FixedUpdate()
    {
        pullSoundTime += Time.deltaTime;

        //�@velosity.x���ω����Ă���A��莞�Ԃ��ƂɈ������鉹��炷
        if ((rbody.velocity.x > 0.5 && pullSoundTime >= 0.4f) || (rbody.velocity.x < -0.5 && pullSoundTime >= 0.4f))
        {
            audioSource.PlayOneShot(pullSound);
            pullSoundTime = 0;
        }
    }
}
