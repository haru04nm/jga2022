using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Stage_Clear : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    [SerializeField]
    GameObject ui;

    [SerializeField]
    List<GameObject> confettiList;

    [SerializeField]
    GameObject firstSelect;

    public static bool clearFlag;

    private void Start()
    {
        ui.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject == player)
        {
            clearFlag = true;
            EventSystem.current.SetSelectedGameObject(firstSelect);
            player.GetComponent<PlayerInput>().actions.FindActionMap("Player").Disable();
            ui.SetActive(true);
            
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
