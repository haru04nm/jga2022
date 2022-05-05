using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonSize : MonoBehaviour
{
    //現在選択中のボタン
    private GameObject currentButton;

    RectTransform[] buttonSize;
    RectTransform currentButtonSize;

    void Start()
    {
        buttonSize = new RectTransform[11]; 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        buttonSize[0] = GameObject.Find("return").GetComponent<RectTransform>();

        buttonSize[0].SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 150);
        buttonSize[0].SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 30);

        for (int i = 1; i <= 10; i++)
        {
            buttonSize[i - 1] = GameObject.Find("stage" + i).GetComponent<RectTransform>();

            buttonSize[i - 1].SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 100);
            buttonSize[i - 1].SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 50);

            buttonSize[i - 1].GetComponentInChildren<Text>().enabled = true;
        }
        
        //現在選択されているボタンを取得し、buttonに代入
        currentButton = EventSystem.current.currentSelectedGameObject;

        currentButtonSize = currentButton.GetComponent<RectTransform>();

        currentButton.GetComponentInChildren<Text>().enabled = false;

        //ボタンのサイズ変更
        currentButtonSize.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 170);
        currentButtonSize.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 85);
    }
}
