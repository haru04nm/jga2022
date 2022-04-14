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

    public static bool clearFlag;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject == player)
        {
            clearFlag = true;
            player.GetComponent<PlayerInput>().actions.FindActionMap("Player").Disable();

            // クリアUI表示
            Select.Instance.ActiveClear();

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
