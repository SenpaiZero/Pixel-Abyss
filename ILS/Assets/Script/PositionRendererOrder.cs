using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionRendererOrder : MonoBehaviour
{
    public MeshRenderer meshR;

    private void Start()
    {
        meshR.sortingOrder = 999;
    }


}
