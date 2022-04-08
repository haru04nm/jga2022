using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Select : MonoBehaviour
{
    public void Title()
    {
        Stage_Clear.clearFlag = false;



        SceneManager.LoadScene("title");
    }

    public void StageSelect()
    {
        Stage_Clear.clearFlag = false;

        SceneManager.LoadScene("StageSelect");
    }

    public void Quit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    public void Stage1()
    {
        Stage_Clear.clearFlag = false;

        SceneManager.LoadScene("Stage1");
    }

    public void Stage2()
    {
        Stage_Clear.clearFlag = false;

        SceneManager.LoadScene("Stage2");
    }

    public void Stage3()
    {
        Stage_Clear.clearFlag = false;

        SceneManager.LoadScene("Stage3");
    }

    public void Stage4()
    {
        Stage_Clear.clearFlag = false;

        SceneManager.LoadScene("Stage3");
    }
}
