using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Select_Buttan : MonoBehaviour
{
    public Button FirstButton;

    void Start()
    {
        // ���߂ɑI�w�肵���{�^����I������
        FirstButton.Select();
    }
}
