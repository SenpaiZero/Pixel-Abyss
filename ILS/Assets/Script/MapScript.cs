using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapScript : MonoBehaviour
{
    public GameObject mapGameobj;

    public void openMap()
    {
        mapGameobj.SetActive(true);
    }

    public void closeMap()
    {
        mapGameobj.SetActive(false);
    }
}
