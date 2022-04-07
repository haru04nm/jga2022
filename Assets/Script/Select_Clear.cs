using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Select_Clear : MonoBehaviour
{
    Button button;

    [SerializeField]
    GameObject ButtonSummary;

    // Start is called before the first frame update
    void Start()
    {
        button = ButtonSummary.GetComponent<Button>();
        button.Select();
    }
}
