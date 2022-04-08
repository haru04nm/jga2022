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
        // 初めに選指定したボタンを選択する
        FirstButton.Select();
    }
}
