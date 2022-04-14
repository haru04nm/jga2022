using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Select : MonoBehaviour
{
    [SerializeField]
    GameObject clearPanel;
    [SerializeField]
    GameObject firstClearSelect;

    [SerializeField]
    GameObject pausePanel;
    [SerializeField]
    GameObject firstPauseSelect;


    GameObject player;

    string nextSceneName;

    static Select instance;

    public static Select Instance
    {
        get { return instance; }
    }

    readonly List<string> NotFadeScene = new List<string>
    {
        //"StageSelect",
    };

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        nextSceneName = "";
        player = GameObject.FindGameObjectWithTag("Player");
        DeactiveClear();
        DeactivePause();
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
        DeactivePause();
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }

    public void ActiveClear()
    {
        EventSystem.current.SetSelectedGameObject(firstClearSelect);
        clearPanel.SetActive(true);
    }
    public void DeactiveClear()
    {
        clearPanel.SetActive(false);
    }

    public void ActivePause()
    {
        EventSystem.current.SetSelectedGameObject(firstPauseSelect);
        pausePanel.SetActive(true);
        player.GetComponent<PlayerInput>().actions.FindActionMap("Player").Disable();

    }

    public void DeactivePause()
    {
        pausePanel.SetActive(false);
        player.GetComponent<PlayerInput>().actions.FindActionMap("Player").Enable();
    }

    public void OnPause(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            ActivePause();
        }
    }
}
