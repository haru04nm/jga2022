using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Select : MonoBehaviour
{
    [SerializeField]
    GameObject panel;
    [SerializeField]
    GameObject firstSelect;

    GameObject player;

    string nextSceneName;

    private void Awake()
    {
        nextSceneName = "";
        player = GameObject.FindGameObjectWithTag("Player");
        Deactive();
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
        FadeOut.IsFadeOut = true;
        nextSceneName = sceneName;
    }

    public void Game()
    {
        Deactive();
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }

    public void Active()
    {
        EventSystem.current.SetSelectedGameObject(firstSelect);
        panel.SetActive(true);

        if(player)
        {
            player.GetComponent<PlayerInput>().actions.FindActionMap("Player").Disable();
        }

    }

    public void Deactive()
    {
        panel.SetActive(false);
        if (player)
        {
            player.GetComponent<PlayerInput>().actions.FindActionMap("Player").Enable();
        }
    }
}
