using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSize : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var size = GetComponent<RectTransform>();

        /*
        if(�I�����ꂽ��)
        {
            //�{�^���̃T�C�Y��傫������
            size.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 4);
            size.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 5);

            //Image ��\��
        }
        else if(�ʂ��I�����ꂽ��)

            //�{�^���̃T�C�Y�����Ƃɖ߂�
            size.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 2);
            size.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 3);

            //Image ���\��
        }
        */
    }
}
