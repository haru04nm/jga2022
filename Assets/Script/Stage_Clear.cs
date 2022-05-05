using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Stage_Clear : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    [SerializeField]
    List<GameObject> confettiList;

    [SerializeField]
    AudioClip clearSound;

    AudioSource audioSource;

    public static bool clearFlag;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject == player)
        {
            clearFlag = true;

            // �N���A�����Ƃ���SE����
            audioSource.PlayOneShot(clearSound);

            player.GetComponent<PlayerInput>().actions.FindActionMap("Player").Disable();

            // �N���AUI�\��
            //Select.Instance.ActiveClear();
            UIClear.Instance.Active();

            foreach (var confetti in confettiList)
            {
                confetti.SetActive(true);
            }
        }
    }

    public bool IsClearFlag
    {
        get
        {
            return clearFlag;
        }

        set
        {
            clearFlag = value;
        }
    }
}
