using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIPause : MonoBehaviour
{
    AudioSource audioSource;

    [SerializeField]
    AudioClip pause;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void OnPause(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            audioSource.PlayOneShot(pause);

            GetComponent<Select>().Active();
        }
    }
}
