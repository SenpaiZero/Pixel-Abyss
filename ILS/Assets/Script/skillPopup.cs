using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class skillPopup : MonoBehaviour
{
    public GameObject popupSkill;

    private void Update()
    {
        if(PlayerPrefs.GetInt("skillPoints") != 0)
        {
            string text_ = PlayerPrefs.GetInt("skillPoints").ToString();

            popupSkill.SetActive(true);
            popupSkill.GetComponentInChildren<TextMeshProUGUI>().text = "You have<color=#0000ffff> " + text_ + " </color>Unused skill points";
        }
        else
        {
            popupSkill.SetActive(false);
        }
    }
}
