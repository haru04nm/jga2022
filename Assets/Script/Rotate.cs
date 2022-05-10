using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField]
    bool direction;

    private void Update()
    {
        if (direction)
        {
            this.transform.Rotate(new Vector3(0, 0, 45) * Time.deltaTime);
        }
        else
        {
            this.transform.Rotate(new Vector3(0, 0, -45) * Time.deltaTime);

        }
    }

}
