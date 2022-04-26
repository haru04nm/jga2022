using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSize : MonoBehaviour
{
    public GameObject Image;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Image を非表示
        Image.SetActive(false);

        var size = GetComponent<RectTransform>();

        /*
        if(選択されたら)
        {
            //ボタンのサイズを大きくする
            size.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 4);
            size.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 5);

            //Image を表示
            Image.SetActive(true);
        }
        else if(別が選択されたら)

            //ボタンのサイズをもとに戻す
            size.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 2);
            size.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 3);

            //Image を非表示
            Image.SetActive(false);
        }
        */
    }
}
