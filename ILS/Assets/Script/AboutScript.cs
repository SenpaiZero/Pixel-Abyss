﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AboutScript : MonoBehaviour
{
    public GameObject aboutObj;

    public void closeAbout()
    {
        aboutObj.SetActive(false);
    }

    public void openAbout()
    {
        aboutObj.SetActive(true);
    }
}
