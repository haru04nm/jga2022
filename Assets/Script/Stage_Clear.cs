using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage_Clear : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    [SerializeField]
    GameObject ui;
    [SerializeField]
    Button FirstButton;

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
            ui.SetActive(true);
            FirstButton.Select();

        }
    }
}
