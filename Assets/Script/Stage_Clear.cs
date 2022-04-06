using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
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

            StartVibration(1.0f, 0.7f, 0.7f);

        }
    }

    //コントローラー振動
    public void Vibration(float l, float r)
    {
        Gamepad.current.SetMotorSpeeds(l, r);
    }

    public void StopVibration()
    {
        Gamepad.current.SetMotorSpeeds(0, 0);
    }
    private IEnumerator LoopVibration(float t, float l, float r)
    {
        Gamepad.current.SetMotorSpeeds(l, r);
        yield return new WaitForSeconds(t);
        StopVibration();
    }

    public void StartVibration(float t, float l, float r)
    {
        StartCoroutine(LoopVibration(t, l, r));
    }
}
