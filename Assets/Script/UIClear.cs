using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIClear : MonoBehaviour
{
    public static UIClear instance;

    public static UIClear Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        instance = this;
    }

    public void Active()
    {
        GetComponent<Select>().Active();
    }
}
