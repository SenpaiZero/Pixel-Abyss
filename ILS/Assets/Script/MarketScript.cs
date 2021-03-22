using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MarketScript : MonoBehaviour
{
    public TextMeshProUGUI hpCount;
    public TextMeshProUGUI mpCount;

    private void Update()
    {
        hpCount.text = "" + PlayerPrefs.GetInt("hpPots");
        mpCount.text = "" + PlayerPrefs.GetInt("manaPots");
    }

    public void shopHP_Pots()
    {
        if (PlayerPrefs.GetInt("Coins") >= 10)
        {
            PlayerPrefs.SetInt("hpPots", PlayerPrefs.GetInt("hpPots") + 1);
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - 20);
            menuSFX();
            PlayerPrefs.Save();
        }
    }

    public void shopMP_Pots()
    {
        if(PlayerPrefs.GetInt("Coins") >= 10)
        {
            PlayerPrefs.SetInt("manaPots", PlayerPrefs.GetInt("manaPots") + 1);
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - 20);
            menuSFX();
            PlayerPrefs.Save();
        }
    }

    void menuSFX()
    {
        GameObject.FindGameObjectWithTag("MenuSfx").GetComponent<menuSFX>().menuSound();
    }
}
