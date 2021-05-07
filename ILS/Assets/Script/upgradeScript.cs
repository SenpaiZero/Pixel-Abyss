using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class upgradeScript : MonoBehaviour
{
    int infoNumber; //1-3 Power
                    //4-6 Magic
                    //7-9 Vitality
                    //10-12 haste
                    //13-15 greed
    string[] infoArr = new string[16];
    int skillPoints;
    bool isIcon = false;

    [SerializeField] GameObject errorPopup;
    [Space]
    [SerializeField]private GameObject upgradeObj;
    [Space]
    [Header("Text")]
    [SerializeField] private TextMeshProUGUI skillPointsTxt;

    [Space]
    [SerializeField] private TextMeshProUGUI MainInfoText;

    [Space]
    [SerializeField] private TextMeshProUGUI powerLevelTxt;
    [SerializeField] private TextMeshProUGUI magicLevelTxt;
    [SerializeField] private TextMeshProUGUI hasteLevelTxt;
    [SerializeField] private TextMeshProUGUI greedLevelTxt;
    [SerializeField] private TextMeshProUGUI vitalityLevelTxt;

    [Space]
    [SerializeField] private TextMeshProUGUI powerText;
    [SerializeField] private TextMeshProUGUI magicText;
    [SerializeField] private TextMeshProUGUI vitalityText;
    [SerializeField] private TextMeshProUGUI hasteText;
    [SerializeField] private TextMeshProUGUI greedText;

    [Space]
    [Header("Icon")]
    [SerializeField] private Image powerlvl5;
    [SerializeField] private Image powerlvl10;
    [SerializeField] private Image powerlvl15;

    [Space]
    [SerializeField] private Image magiclvl5;
    [SerializeField] private Image magiclvl10;
    [SerializeField] private Image magiclvl15;

    [Space]
    [SerializeField] private Image vitalitylvl5;
    [SerializeField] private Image vitalitylvl10;
    [SerializeField] private Image vitalitylvl15;

    [Space]
    [SerializeField] private Image hastelvl5;
    [SerializeField] private Image hastelvl10;
    [SerializeField] private Image hastelvl15;

    [Space]
    [SerializeField] private Image greedlvl5;
    [SerializeField] private Image greedlvl10;
    [SerializeField] private Image greedlvl15;

    [Space]
    [Header("Button Upgrade")]
    [SerializeField] private Button powerBtn; 
    [SerializeField] private Button magicBtn; 
    [SerializeField] private Button vitalityBtn; 
    [SerializeField] private Button hasteBtn; 
    [SerializeField] private Button greedBtn; 

    private void Start()
    {
        //power
        infoArr[1] = "<color=#e64141>power \n level 5</color> \n 2x critical chance and 3x critical damage";
        infoArr[2] = "<color=#e64141>power \n level 10</color> \n Shoots 2 bullets instead of 1";
        infoArr[3] = "<color=#e64141>power \n level 15</color> \n bullets can go through 2 enemies";
        //magic
        infoArr[4] = "<color=#003e7c>magic \n level 5</color> \n Double the effect of potions";
        infoArr[5] = "<color=#003e7c>magic \n level 10</color> \n Killing enemy gives you 5 mana";
        infoArr[6] = "<color=#003e7c>magic \n level 15</color> \n Reduces mana consumption to 50%";
        //vitality
        infoArr[7] = "<color=#000000>vitality \n level 5</color> \n Killing enemy gives you gives you 5 health";
        infoArr[8] = "<color=#000000>vitality \n level 10</color> \n Reduces damage taken by 30%";
        infoArr[9] = "<color=#000000>vitality \n level 15</color> \n You have 20% chance blocking an attack";
        //haste
        infoArr[10] = "<color=#56a811>haste \n level 5</color> \n 10% more movement speed";
        infoArr[11] = "<color=#56a811>haste \n level 10</color> \n Gain 20% movement speed after using skill for 2 seconds";
        infoArr[12] = "<color=#56a811>haste \n level 15</color> \n Immune to all slow and poison effects";
        //greed
        infoArr[13] = "<color=#e6aa1f>greed \n level 5</color> \n You will not lose coins and exp when you died";
        infoArr[14] = "<color=#e6aa1f>greed \n level 10</color> \n Double the exp and coin gain";
        infoArr[15] = "<color=#e6aa1f>greed \n level 15</color> \n You will have infinite potion but cooldown of potions will get tripled";

        MainInfoText.text = "<color=#e64141>power</color> - EACH LEVEL GIVES YOU 5 DAMAGE AND 1% CRITICAL CHANCE \n" +
                            "<color=#000000>vitality</color> - EACH LEVEL GIVES YOU 10 HEALTH AND 0.5 HEALTH REGEN \n" +
                            "<color=#003e7c>magic</color> - EACH LEVEL GIVES YOU 3% COOLDOWN REDUCTION, 10 MANA AND 0.5 MANA REGEN \n" +
                            "<color=#56a811>haste</color> - EACH LEVEL GIVES YOU 6% ATTACK SPEED and 3% MOVEMENT SPEED \n" +
                            "<color=#e6aa1f>greed</color> - EACH LEVEL GIVES YOU EXTRA 5% COINS AND 5% EXTRA EXP \n" +
                            "<color=yellow> CLICK ON ICON OF SKILL TO LEARN MORE ABOUT THEM </color>";
    }

    private void Update()
    {
        skillPoints = PlayerPrefs.GetInt("skillPoints");
        skillPointsTxt.text = "SKILL POINTS: " + skillPoints;

        powerLevelTxt.text = "POWER<size=250>\n" + PlayerPrefs.GetInt("powerLevel") + " </size>";
        magicLevelTxt.text = "MAGIC<size=250>\n" + PlayerPrefs.GetInt("magicLevel") + " </size>";
        hasteLevelTxt.text = "HASTE<size=250>\n" + PlayerPrefs.GetInt("hasteLevel") + " </size>";
        vitalityLevelTxt.text = "VITALITY<size=250>\n" + PlayerPrefs.GetInt("vitalityLevel") + " </size>";
        greedLevelTxt.text = "GREED<size=250>\n" + PlayerPrefs.GetInt("greedLevel") + " </size>";

        switch (infoNumber)
        {
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
            case 15:
                MainInfoText.text = infoArr[infoNumber];
                break;

        }

        if (isIcon == false)
        {
            StartCoroutine("delayIconImage");
        }

        powerText.text = "" + PlayerPrefs.GetFloat("wandDamage") + " Damage \n" + PlayerPrefs.GetFloat("critChance") + "% CRIT CHANCE";
        magicText.text = "" + PlayerPrefs.GetFloat("mana") + " MANA \n" + PlayerPrefs.GetFloat("manaRegen") + " mana regen \n" + PlayerPrefs.GetFloat("cdr") + "% Cooldown Reduction";
        vitalityText.text = "" + PlayerPrefs.GetFloat("health") + " health \n" + PlayerPrefs.GetFloat("healthRegen") + " health regen";
        greedText.text = "" + PlayerPrefs.GetInt("extraCoins") + "x extra coins \n" + PlayerPrefs.GetFloat("extraEXP") + "x extra exp";
        hasteText.text = "" + PlayerPrefs.GetInt("attackSpeedCounter") + "% attack speed \n" + PlayerPrefs.GetInt("movementSpeedCounter") + "% movement speed";

        if(PlayerPrefs.GetInt("powerLevel") == 15)
        {
            powerBtn.interactable = false;
            powerBtn.GetComponentInChildren<TextMeshProUGUI>().text = "MAX";
        }
        if(PlayerPrefs.GetInt("magicLevel") == 15)
        {
            magicBtn.interactable = false;
            magicBtn.GetComponentInChildren<TextMeshProUGUI>().text = "MAX";
        }
        if(PlayerPrefs.GetInt("hasteLevel") == 15)
        {
            hasteBtn.interactable = false;
            hasteBtn.GetComponentInChildren<TextMeshProUGUI>().text = "MAX";
        }
        if(PlayerPrefs.GetInt("vitalityLevel") == 15)
        {
            vitalityBtn.interactable = false;
            vitalityBtn.GetComponentInChildren<TextMeshProUGUI>().text = "MAX";
        }
        if(PlayerPrefs.GetInt("greedLevel") == 15)
        {
            greedBtn.interactable = false;
            greedBtn.GetComponentInChildren<TextMeshProUGUI>().text = "MAX";
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
                PlayerPrefs.SetFloat("critChance", PlayerPrefs.GetFloat("critChance") + 2f * PlayerPrefs.GetFloat("critChanceMul")); //2% max is 30%
                PlayerPrefs.SetInt("powerLevel", PlayerPrefs.GetInt("powerLevel") + 1);
                PlayerPrefs.SetInt("skillPoints", PlayerPrefs.GetInt("skillPoints") - 1);
                PlayerPrefs.SetInt("skillSpent", PlayerPrefs.GetInt("skillSpent") + 1);

                //lvl5
                if(PlayerPrefs.GetInt("powerLevel") >= 5)
                {
                    PlayerPrefs.SetInt("critDamage", 3);
                    PlayerPrefs.SetFloat("critChanceMul", 2);
                }

                //lvl10
                if(PlayerPrefs.GetInt("powerLevel") >= 10)
                {
                    PlayerPrefs.SetString("doubleShot", "true");
                }

                //lvl15
                if(PlayerPrefs.GetInt("powerLevel") >= 10)
                {
                    PlayerPrefs.SetString("bulletAOE", "true");
                }
                PlayerPrefs.Save();
            }
            else
            {
                GameObject clone = Instantiate(errorPopup, transform.position, Quaternion.identity);
                clone.transform.parent = gameObject.transform;
            }
        }
    }

    public void upgradeMagic()
    {
        if(PlayerPrefs.GetInt("magicLevel") < 15)
        {
            if(skillPoints >= 1)
            {
                sfxMenu();
                PlayerPrefs.SetFloat("cdr", PlayerPrefs.GetFloat("cdr") + 3); //3% so upto 50% when max or 1/2
                PlayerPrefs.SetFloat("mana", PlayerPrefs.GetFloat("mana") + 10);
                PlayerPrefs.SetFloat("manaRegen", PlayerPrefs.GetFloat("manaRegen") + 0.5f);
                PlayerPrefs.SetInt("magicLevel", PlayerPrefs.GetInt("magicLevel") + 1);
                PlayerPrefs.SetInt("skillPoints", PlayerPrefs.GetInt("skillPoints") - 1);
                PlayerPrefs.SetInt("skillSpent", PlayerPrefs.GetInt("skillSpent") + 1);

                //level 5
                if(PlayerPrefs.GetInt("magicLevel") >= 5)
                {
                    PlayerPrefs.SetFloat("doublePots", 2);
                }

                //level 10
                if(PlayerPrefs.GetInt("magicLevel") >= 10)
                {
                    PlayerPrefs.SetString("manaPerKill", "true");
                }

                //level 15
                if(PlayerPrefs.GetInt("magicLevel") >= 15)
                {
                    PlayerPrefs.SetInt("50ManaPercent", 2);
                }

                PlayerPrefs.Save();
            }
            else
            {
                GameObject clone = Instantiate(errorPopup, transform.position, Quaternion.identity);
                clone.transform.parent = gameObject.transform;
            }
        }
    }
    public void upgradeHaste()
    {
        if(PlayerPrefs.GetInt("hasteLevel") < 15)
        {
            if(skillPoints >= 1)
            {
                sfxMenu();
                PlayerPrefs.SetFloat("movementSpeed", PlayerPrefs.GetFloat("movementSpeed") + 0.18f); //3% which is 15% max or 2.7f
                PlayerPrefs.SetFloat("attackSpeed", PlayerPrefs.GetFloat("attackSpeed") - 0.04f);
                PlayerPrefs.SetInt("attackSpeedCounter", PlayerPrefs.GetInt("attackSpeedCounter") + 6);
                PlayerPrefs.SetInt("movementSpeedCounter", PlayerPrefs.GetInt("movementSpeedCounter") + 3);
                PlayerPrefs.SetInt("hasteLevel", PlayerPrefs.GetInt("hasteLevel") + 1);
                PlayerPrefs.SetInt("skillPoints", PlayerPrefs.GetInt("skillPoints") - 1);
                PlayerPrefs.SetInt("skillSpent", PlayerPrefs.GetInt("skillSpent") + 1);

                //lvl5
                if(PlayerPrefs.GetInt("hasteLevel") >= 5)
                {
                    PlayerPrefs.SetFloat("bonusMovement", 1.1f);
                }

                //lvl10
                if (PlayerPrefs.GetInt("hasteLevel") >= 10)
                {
                    PlayerPrefs.SetString("bonusMovementKillBool", "true");
                }

                //lvl15
                if(PlayerPrefs.GetInt("hasteLevel") >= 15)
                {
                    PlayerPrefs.SetString("immuneSlow", "true");
                }

                PlayerPrefs.Save();
            }
            else
            {
                GameObject clone = Instantiate(errorPopup, transform.position, Quaternion.identity);
                clone.transform.parent = gameObject.transform;
            }
        }
    }
    public void upgradeVitality()
    {
        if(PlayerPrefs.GetInt("vitalityLevel") < 15)
        {
            if(skillPoints >= 1)
            {
                sfxMenu();
                PlayerPrefs.SetFloat("health", PlayerPrefs.GetFloat("health") + 10);
                PlayerPrefs.SetFloat("healthRegen", PlayerPrefs.GetFloat("healthRegen") + 0.5f);
                PlayerPrefs.SetInt("vitalityLevel", PlayerPrefs.GetInt("vitalityLevel") + 1);
                PlayerPrefs.SetInt("skillPoints", PlayerPrefs.GetInt("skillPoints") - 1);
                PlayerPrefs.SetInt("skillSpent", PlayerPrefs.GetInt("skillSpent") + 1);

                //lvl5
                if(PlayerPrefs.GetInt("vitalityLevel") >= 5)
                {
                    PlayerPrefs.SetString("HPperKill", "true");
                }
                //lvl10
                if(PlayerPrefs.GetInt("vitalityLevel") >= 10)
                {
                    PlayerPrefs.SetFloat("damageReduction", 3); //30%
                }
                //lvl15
                if(PlayerPrefs.GetInt("vitalityLevel") >= 15)
                {
                    PlayerPrefs.SetString("blockDamage", "true");
                }
                PlayerPrefs.Save();
            }
            else
            {
                GameObject clone = Instantiate(errorPopup, transform.position, Quaternion.identity);
                clone.transform.parent = gameObject.transform;
            }
        }
    }
    public void upgradeGreed()
    {
        if(PlayerPrefs.GetInt("greedLevel") < 15)
        {
            if(skillPoints >= 1)
            {
                sfxMenu();
                PlayerPrefs.SetInt("extraCoins", PlayerPrefs.GetInt("extraCoins") + 1); //x1
                PlayerPrefs.SetFloat("extraEXP", PlayerPrefs.GetFloat("extraEXP") + 1); //x1
                PlayerPrefs.SetInt("greedLevel", PlayerPrefs.GetInt("greedLevel") + 1);
                PlayerPrefs.SetInt("skillPoints", PlayerPrefs.GetInt("skillPoints") - 1);
                PlayerPrefs.SetInt("skillSpent", PlayerPrefs.GetInt("skillSpent") + 1);

                //level5
                if(PlayerPrefs.GetInt("greedLevel") >= 5)
                {
                    PlayerPrefs.SetString("loseItemOnDead", "false");
                }
                //level10
                if(PlayerPrefs.GetInt("greedLevel") >= 10)
                {
                    PlayerPrefs.SetInt("doubleDrop", 2);
                }
                //level15
                if(PlayerPrefs.GetInt("greedLevel") >= 15)
                {
                    PlayerPrefs.SetString("infinitePots", "true");
                }

                PlayerPrefs.Save();
            } else
            {
                GameObject clone = Instantiate(errorPopup, transform.position, Quaternion.identity);
                clone.transform.parent = gameObject.transform;
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
        PlayerPrefs.SetFloat("movementSpeed", 6f);
        PlayerPrefs.SetFloat("critChance", 5);
        PlayerPrefs.SetFloat("cdr", 0);
        PlayerPrefs.SetInt("attackSpeedCounter", 0);
        PlayerPrefs.SetInt("movementSpeedCounter", 0);
        PlayerPrefs.SetInt("extraCoins", 1);
        PlayerPrefs.SetFloat("extraEXP", 1);

        PlayerPrefs.SetFloat("health", 50);
        PlayerPrefs.SetFloat("healthRegen", 1);
        PlayerPrefs.SetFloat("manaRegen", 1);
        PlayerPrefs.SetFloat("mana", 50);


        PlayerPrefs.SetInt("powerLevel", 0);
        PlayerPrefs.SetInt("magicLevel", 0);
        PlayerPrefs.SetInt("hasteLevel", 0);
        PlayerPrefs.SetInt("vitalityLevel", 0);
        PlayerPrefs.SetInt("greedLevel", 0);

        powerBtn.GetComponentInChildren<TextMeshProUGUI>().text = "UPGRADE";
        magicBtn.GetComponentInChildren<TextMeshProUGUI>().text = "UPGRADE";
        hasteBtn.GetComponentInChildren<TextMeshProUGUI>().text = "UPGRADE";
        vitalityBtn.GetComponentInChildren<TextMeshProUGUI>().text = "UPGRADE";
        greedBtn.GetComponentInChildren<TextMeshProUGUI>().text = "UPGRADE";

        powerBtn.interactable = true;
        magicBtn.interactable = true;
        hasteBtn.interactable = true;
        vitalityBtn.interactable = true;
        greedBtn.interactable = true;

        //Power Level 5,10,15
        PlayerPrefs.SetInt("critDamage", 2);
        PlayerPrefs.SetFloat("critChanceMul", 1);
        PlayerPrefs.SetString("doubleShot", "false");
        PlayerPrefs.SetString("bulletAOE", "false");

        //magic level 5,10,15
        PlayerPrefs.SetFloat("doublePots", 1);
        PlayerPrefs.SetString("manaPerKill", "false");
        PlayerPrefs.SetInt("50ManaPercent", 1);

        //vitality level 5,10,15
        PlayerPrefs.SetString("HPperKill", "false");
        PlayerPrefs.SetFloat("damageReduction", 1);
        PlayerPrefs.SetString("blockDamage", "false");

        //haste level5,10,15
        PlayerPrefs.SetFloat("bonusMovement", 1f);
        PlayerPrefs.SetString("bonusMovementKillBool", "false");
        PlayerPrefs.SetString("immuneSlow", "false");

        //greed level5,10,15
        PlayerPrefs.SetString("loseItemOnDead", "true");
        PlayerPrefs.SetInt("doubleDrop", 1);
        PlayerPrefs.SetString("infinitePots", "false");
        PlayerPrefs.Save();

    }

    void sfxMenu()
    {
        GameObject.FindGameObjectWithTag("MenuSfx").GetComponent<menuSFX>().menuSound();
    }

    //etc btn for icons skill
    //1-3 Power
    //4-6 Magic
    //7-9 Vitality
    //10-12 haste
    //13-15 greed

    public void power5()
    {
        infoNumber = 1;
        sfxMenu();
    }
    public void power10()
    {
        infoNumber = 2;
        sfxMenu();
    }
    public void power15()
    {
        infoNumber = 3;
        sfxMenu();
    }
    public void magic5()
    {
        infoNumber = 4;
        sfxMenu();
    }
    public void magic10()
    {
        infoNumber = 5;
        sfxMenu();
    }
    public void magic15()
    {
        infoNumber = 6;
        sfxMenu();
    }
    public void vitality5()
    {
        infoNumber = 7;
        sfxMenu();
    }
    public void vitality10()
    {
        infoNumber = 8;
        sfxMenu();
    }
    public void vitality15()
    {
        infoNumber = 9;
        sfxMenu();
    }
    public void haste5()
    {
        infoNumber = 10;
        sfxMenu();
    }
    public void haste10()
    {
        infoNumber = 11;
        sfxMenu();
    }
    public void haste15()
    {
        infoNumber = 12;
        sfxMenu();
    }
    public void greed5()
    {
        infoNumber = 13;
        sfxMenu();
    }
    public void greed10()
    {
        infoNumber = 14;
        sfxMenu();
    }
    public void greed15()
    {
        infoNumber = 15;
        sfxMenu();
    }

    IEnumerator delayIconImage()
    {
        isIcon = true;
        
        //power
        if(PlayerPrefs.GetInt("powerLevel") >= 5)
        {
            powerlvl5.color = Color.white;
        }
        else
        {
            powerlvl5.color = Color.grey;
        }
        if(PlayerPrefs.GetInt("powerLevel") >= 10)
        {
            powerlvl10.color = Color.white;
        }
        else
        {
            powerlvl10.color = Color.grey;
        }
        if(PlayerPrefs.GetInt("powerLevel") >= 15)
        {
            powerlvl15.color = Color.white;
        }
        else
        {
            powerlvl15.color = Color.grey;
        }
        //magic
        if(PlayerPrefs.GetInt("magicLevel") >= 5)
        {
            magiclvl5.color = Color.white;
        }
        else
        {
            magiclvl5.color = Color.grey;
        }
        if (PlayerPrefs.GetInt("magicLevel") >= 10)
        {
            magiclvl10.color = Color.white;
        }
        else
        {
            magiclvl10.color = Color.grey;
        }
        if(PlayerPrefs.GetInt("magicLevel") >= 15)
        {
            magiclvl15.color = Color.white; 
        }
        else
        {
            magiclvl15.color = Color.grey;
        }
        //vitality
        if (PlayerPrefs.GetInt("vitalityLevel") >= 5)
        {
            vitalitylvl5.color = Color.white;
        }
        else
        {
            vitalitylvl5.color = Color.grey; 
        }
        if(PlayerPrefs.GetInt("vitalityLevel") >= 10)
        {
            vitalitylvl10.color = Color.white;
        }
        else
        {
            vitalitylvl10.color = Color.grey;
        }
        if (PlayerPrefs.GetInt("vitalityLevel") >= 15)
        {
            vitalitylvl15.color = Color.white;
        }
        else
        {
            vitalitylvl15.color = Color.grey;
        }
        //greed
        if(PlayerPrefs.GetInt("greedLevel") >= 5)
        {
            greedlvl5.color = Color.white;
        }
        else
        {
            greedlvl5.color = Color.grey;
        }
        if(PlayerPrefs.GetInt("greedLevel") >= 10)
        {
            greedlvl10.color = Color.white;
        }
        else
        {
            greedlvl10.color = Color.grey;
        }
        if(PlayerPrefs.GetInt("greedLevel") >= 15)
        {
            greedlvl15.color = Color.white;
        }
        else
        {
            greedlvl15.color = Color.grey;
        }
        //haste
        if(PlayerPrefs.GetInt("hasteLevel") >= 5)
        {
            hastelvl5.color = Color.white;
        }
        else
        {
            hastelvl5.color = Color.grey;
        }
        if(PlayerPrefs.GetInt("hasteLevel") >= 10)
        {
            hastelvl10.color = Color.white;
        }
        else
        {
            hastelvl10.color = Color.grey;
        }
        if(PlayerPrefs.GetInt("hasteLevel") >= 15)
        {
            hastelvl15.color = Color.white;
        }
        else
        {
            hastelvl15.color = Color.grey;
        }

        yield return new WaitForSeconds(0.1f);
        isIcon = false;
    }
}
