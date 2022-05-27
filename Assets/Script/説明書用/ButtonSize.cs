using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonSize : MonoBehaviour
{
    private GameObject returnButton;

    //���ݑI�𒆂̃{�^��
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
        returnButton = GameObject.Find("return");
        buttonSize[0] = returnButton.GetComponent<RectTransform>();

        //�^�C�g���ɖ߂�{�^���@�T�C�Y������
        buttonSize[0].SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 230);
        buttonSize[0].SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 45);

        //  1�`10�̃X�e�[�W�I���{�^���@�T�C�Y������
        for (int i = 1; i <= 10; i++)
        {
            buttonSize[i - 1] = GameObject.Find("stage" + i).GetComponent<RectTransform>();

            buttonSize[i - 1].SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 150);
            buttonSize[i - 1].SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 70);

            buttonSize[i - 1].GetComponentInChildren<Text>().enabled = true;
        }
        
        //���ݑI������Ă���{�^�����擾���Abutton�ɑ��
        currentButton = EventSystem.current.currentSelectedGameObject;

        if(currentButton != returnButton)
        {
            currentButtonSize = currentButton.GetComponent<RectTransform>();

            currentButton.GetComponentInChildren<Text>().enabled = false;

            //�{�^���̃T�C�Y�ύX
            currentButtonSize.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 200);
            currentButtonSize.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 100);
        }
    }
}
