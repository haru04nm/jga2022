using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Select : MonoBehaviour
{
    public void Title()
    {
        SceneManager.LoadScene("title");
    }

    public void StageSelect()
    {
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
        SceneManager.LoadScene("Stage1");
    }

    public void Stage2()
    {
        SceneManager.LoadScene("Stage2");
    }

    public void Stage3()
    {
        SceneManager.LoadScene("Stage3");
    }

    public void Stage4()
    {
        SceneManager.LoadScene("Stage3");
    }
}
