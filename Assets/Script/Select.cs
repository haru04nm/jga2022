using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Select : MonoBehaviour
{
    [SerializeField]
    GameObject cursor;

    Vector3 move;

    const float Speed = 1.0f;

    bool isSelectFlag;

    int id;

    const int StageNum = 3;

    private void Start()
    {
        isSelectFlag = false; 
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
    }

    public void OnFire(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            StageSelect();
        }
    }

    public void OnSelect(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            if (isSelectFlag)
            {
                for(int i = 0; i <= StageNum; i++)
                {
                    if (id == i)
                    {
                        SceneManager.LoadScene("Stage" + i);
                    }
                }
            }
        }
    }

    private void FixedUpdate()
    {
        Vector3 CursorPos = cursor.transform.position;

        if (CursorPos.x >= -80 && CursorPos.x <= 80 && CursorPos.y >= -40 && CursorPos.y <= 40)
        {
            CursorPos += move * Speed;
        }
        
        CursorPos.x = Mathf.Clamp(CursorPos.x, -80, 80);
        CursorPos.y = Mathf.Clamp(CursorPos.y, -40, 40);

        cursor.transform.position = CursorPos;
    }

    public void StageSelect()
    {
        Vector2 mousePosition = cursor.transform.position;
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

        isSelectFlag = false;

        if (hit && hit.collider.GetComponent<Scene>())
        {
            Scene scene = hit.collider.GetComponent<Scene>();

            id = scene.id;

            if (id > 0)
            {
                isSelectFlag = true;
            }
            Debug.Log(id);
        } 
    }
}
