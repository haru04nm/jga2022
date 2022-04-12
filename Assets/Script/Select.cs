using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Select : MonoBehaviour
{
    string nextSceneName;
    readonly List<string> NotFadeScene = new List<string>
    {
        //"StageSelect",
    };

    private void Start()
    {
        nextSceneName = "";
    }

    private void FixedUpdate()
    {
        if (nextSceneName != "" && !FadeOut.IsFadeOut)
        {
            Stage_Clear.clearFlag = false;
            SceneManager.LoadScene(nextSceneName);
        }
    }

    public void Button(string sceneName)
    {
        FadeOut.IsFadeOut = NotFadeScene.IndexOf(sceneName) == -1;
        nextSceneName = sceneName;
    }

    public void Quit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
