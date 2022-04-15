using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creat_Slope : MonoBehaviour
{
    [SerializeField]
    GameObject Slope;

    private void Start()
    {
        Slope.gameObject.SetActive(true);
        this.gameObject.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        Slope.gameObject.SetActive(false);
        this.gameObject.SetActive(false);

    }
}
