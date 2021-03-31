using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class upgradeScript : MonoBehaviour
{
    int infoNumber; //0-2 Power
                    //3-5 Magic
                    //6-8 Vitality
                    //9-11 haste
                    //12-14 greed
    string[] infoArr = new string[14];
    int skillPoints;
    

    [SerializeField]private GameObject upgradeObj;
    [Space]
    [Header("Text")]
    [SerializeField] private TextMeshProUGUI skillPointsTxt;

    [Space]
    [SerializeField] private TextMeshProUGUI MainInfoText;
    [SerializeField] private TextMeshProUGUI PowerInfoText;
    [SerializeField] private TextMeshProUGUI MagicInfoText;
    [SerializeField] private TextMeshProUGUI VitalityInfoText;
    [SerializeField] private TextMeshProUGUI HasteInfoText;
    [SerializeField] private TextMeshProUGUI GreedInfoText;

    [Space]
    [SerializeField] private TextMeshProUGUI powerLevelTxt;
    [SerializeField] private TextMeshProUGUI magicLevelTxt;
    [SerializeField] private TextMeshProUGUI hasteLevelTxt;
    [SerializeField] private TextMeshProUGUI greedLevelTxt;
    [SerializeField] private TextMeshProUGUI vitalityLevelTxt;


    private void Start()
    {
        //power
        infoArr[0] = "";
        infoArr[1] = "";
        infoArr[2] = "";
        //magic
        infoArr[3] = "";
        infoArr[4] = "";
        infoArr[5] = "";
        //vitality
        infoArr[6] = "";
        infoArr[7] = "";
        infoArr[8] = "";
        //haste
        infoArr[9] = "";
        infoArr[10] = "";
        infoArr[11] = "";
        //greed
        infoArr[12] = "";
        infoArr[13] = "";
        infoArr[14] = "";
    }

    private void Update()
    {
        skillPoints = PlayerPrefs.GetInt("skillPoints");
        skillPointsTxt.text = "" + skillPoints;

        powerLevelTxt.text = "POWER<size=250>\n" + PlayerPrefs.GetInt("powerLevel") + " </size>";
        magicLevelTxt.text = "MAGIC<size=250>\n" + PlayerPrefs.GetInt("magicLevel") + " </size>";
        hasteLevelTxt.text = "HASTE<size=250>\n" + PlayerPrefs.GetInt("hasteLevel") + " </size>";
        vitalityLevelTxt.text = "VITALITY<size=250>\n" + PlayerPrefs.GetInt("vitalityLevel") + " </size>";
        greedLevelTxt.text = "GREED<size=250>\n" + PlayerPrefs.GetInt("greedLevel") + " </size>";

        switch(infoNumber)
        {
            case 0:
                MainInfoText.text = infoArr[infoNumber];
                break;
            case 1:
                MainInfoText.text = infoArr[infoNumber];
                break;
            case 2:
                MainInfoText.text = infoArr[infoNumber];
                break;
            case 3:
                MainInfoText.text = infoArr[infoNumber];
                break;
            case 4:
                MainInfoText.text = infoArr[infoNumber];
                break;
            case 5:
                MainInfoText.text = infoArr[infoNumber];
                break;
            case 6:
                MainInfoText.text = infoArr[infoNumber];
                break;
            case 7:
                MainInfoText.text = infoArr[infoNumber];
                break;
            case 8:
                MainInfoText.text = infoArr[infoNumber];
                break;
            case 9:
                MainInfoText.text = infoArr[infoNumber];
                break;
            case 10:
                MainInfoText.text = infoArr[infoNumber];
                break;
            case 11:
                MainInfoText.text = infoArr[infoNumber];
                break;
            case 12:
                MainInfoText.text = infoArr[infoNumber];
                break;
            case 13:
                MainInfoText.text = infoArr[infoNumber];
                break;
            case 14:
                MainInfoText.text = infoArr[infoNumber];
                break;

        }
    }

    public void upgradePower()
    {
        if (PlayerPrefs.GetInt("powerLevel") < 15)
        {
            if (skillPoints >= 1)
            {
                sfxMenu();
                PlayerPrefs.SetFloat("wandDamage", PlayerPrefs.GetFloat("wandDamage") + 5f);
                PlayerPrefs.SetFloat("critChance", PlayerPrefs.GetFloat("critChance") + 2f);
                PlayerPrefs.SetInt("powerLevel", PlayerPrefs.GetInt("powerLevel") + 1);
                PlayerPrefs.SetInt("skillPoints", PlayerPrefs.GetInt("skillPoints") - 1);
                PlayerPrefs.Save();
            }
        }
    }

    public void upgradeClose()
    {
        sfxMenu();
        upgradeObj.SetActive(false);
    }

    public void ResetSkill()
    {
        sfxMenu();
        PlayerPrefs.SetInt("skillPoints", PlayerPrefs.GetInt("skillPoints") + PlayerPrefs.GetInt("skillSpent"));
        PlayerPrefs.SetInt("skillSpent", 0);
        PlayerPrefs.SetFloat("wandDamage", 10f);
        PlayerPrefs.SetFloat("attackSpeed", 1f);
        PlayerPrefs.SetFloat("atkSpdCount", 1);


        PlayerPrefs.SetFloat("health", 50);
        PlayerPrefs.SetFloat("healthRegen", 1);
        PlayerPrefs.SetFloat("manaRegen", 1);
        PlayerPrefs.SetFloat("mana", 50);


        PlayerPrefs.SetInt("powerLevel", 0);
        PlayerPrefs.SetInt("magicLevel", 0);
        PlayerPrefs.SetInt("hasteLevel", 0);
        PlayerPrefs.SetInt("vitalityLevel", 0);
        PlayerPrefs.SetInt("greedLevel", 0);
    }

    void sfxMenu()
    {
        GameObject.FindGameObjectWithTag("MenuSfx").GetComponent<menuSFX>().menuSound();
    }
}
