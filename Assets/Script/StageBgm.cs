using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageBgm : MonoBehaviour
{
    [SerializeField] AudioClip clip;

    void Start()
    {
        AudioSource audio = GameObject.Find("audio").GetComponent<AudioSource>();
        audio.clip = clip;
        audio.volume = 1f;
    }
}
