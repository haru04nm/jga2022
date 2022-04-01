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

    public void PushButtan_Title()
    {
        SceneManager.LoadScene("title");
    }

    public void PushButtan__Stage1()
    {
        SceneManager.LoadScene("Stage1");
    }

    public void PushButtan__Stage2()
    {
        SceneManager.LoadScene("Stage2");
    }


}
