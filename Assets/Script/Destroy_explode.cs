using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_explode : MonoBehaviour
{
    float destroyTime;


    private void Update()
    {
        destroyTime += Time.deltaTime;
        if (destroyTime >= 0.7f)
        {
            Destroy(this.gameObject);
        }
    }
}
