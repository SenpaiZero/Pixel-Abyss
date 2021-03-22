using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapScript : MonoBehaviour
{
    public GameObject mapGameobj;

    public void openMap()
    {
        mapGameobj.SetActive(true);
        GameObject.FindGameObjectWithTag("MenuSfx").GetComponent<menuSFX>().menuSound();
    }

    public void closeMap()
    {
        mapGameobj.SetActive(false);
        GameObject.FindGameObjectWithTag("MenuSfx").GetComponent<menuSFX>().menuSound();
    }
}
