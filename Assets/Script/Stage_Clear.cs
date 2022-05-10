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
    AudioClip clearSound;

    AudioSource audioSource;

    public static bool clearFlag;

    GameObject kami;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        kami = GameObject.Find("紙吹雪").gameObject;
        kami.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject == player)
        {
            clearFlag = true;

            // クリアしたときにSE流す
            audioSource.PlayOneShot(clearSound);

            player.GetComponent<PlayerInput>().actions.FindActionMap("Player").Disable();

            // クリアUI表示
            //Select.Instance.ActiveClear();
            UIClear.Instance.Active();

            //紙吹雪ON
            kami.SetActive(true);
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
