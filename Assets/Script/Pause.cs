using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Pause : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    [SerializeField]
    GameObject ui;

    // Start is called before the first frame update
    void Start()
    {
        ui.SetActive(false);
    }

    public void OnPause(InputAction.CallbackContext context)
    {
        Debug.Log("!");

        if (context.phase == InputActionPhase.Started)
        {
            Debug.Log("!!!");
            ui.SetActive(true);
            player.GetComponent<PlayerInput>().actions.FindActionMap("Player").Disable();
        }
    }
}
