using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherIndex : MonoBehaviour
{
    [SerializeField]
    int barreleIndex;

    [SerializeField]
    int togeIndex;

    public int IsBarreleIndex
    {
        get
        {
            return barreleIndex;
        }
    }

    public int IsTogeIndex
    {
        get
        {
            return togeIndex;
        }
    }
}
