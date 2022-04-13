using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class Select : MonoBehaviour
{
    [SerializeField]
    GameObject ui;

    [SerializeField]
    GameObject player;

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

    public void game()
    {
        ui.SetActive(false);
        player.GetComponent<PlayerInput>().actions.FindActionMap("Player").Enable();
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
