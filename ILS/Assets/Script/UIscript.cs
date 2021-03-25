using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIscript : MonoBehaviour
{
    [Header("Button UI")]
    public Button btnTop;
    public Button btnMid;
    public Button btnBot;

    void Start()
    {
        btnBot.GetComponent<Image>().alphaHitTestMinimumThreshold = 0.1f;
        btnMid.GetComponent<Image>().alphaHitTestMinimumThreshold = 0.1f;
        btnTop.GetComponent<Image>().alphaHitTestMinimumThreshold = 0.1f;
        this.GetComponent<Image>().alphaHitTestMinimumThreshold = 0.1f;
    }

}
