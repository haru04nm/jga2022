using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIStageSelect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Select>().Active();
    }
   
}
