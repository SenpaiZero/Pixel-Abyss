using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class upgradeScript : MonoBehaviour
{
    //STATS
    public TextMeshProUGUI maxHp;
    public TextMeshProUGUI maxMana;
    public TextMeshProUGUI regenMana;
    public TextMeshProUGUI regenHP;
    public TextMeshProUGUI dmg;
    public TextMeshProUGUI atkSpd;

    public TextMeshProUGUI skillPts;

    [Space]
    public GameObject upgrade;


    private void Update()
    {
        maxHp.text = "MAX HEALTH: " + PlayerPrefs.GetFloat("health");
        maxMana.text = "MAX MANA: " + PlayerPrefs.GetFloat("mana");
        regenMana.text = "MANA REGEN PER SEC: " + PlayerPrefs.GetFloat("manaRegen");
        regenHP.text = "HEALTH REGEN PER SEC: " + PlayerPrefs.GetFloat("healthRegen");
        dmg.text = "DAMAGE: " + PlayerPrefs.GetFloat("wandDamage");
        atkSpd.text = "ATTACK SPEED: " + PlayerPrefs.GetFloat("atkSpdCount");
        skillPts.text = "SKILL POINTS: " + PlayerPrefs.GetInt("skillPoints");
    }


    //Max HP
    public void maxHpUpgrade()
    {
        if(PlayerPrefs.GetInt("skillPoints") >= 1)
        {
            PlayerPrefs.SetFloat("health", PlayerPrefs.GetFloat("health") + 10);
            PlayerPrefs.SetInt("skillPoints", PlayerPrefs.GetInt("skillPoints") - 1);
            PlayerPrefs.Save();
        }
    }

    //MAX MANA
    public void maxManaUpgrade()
    {
        if (PlayerPrefs.GetInt("skillPoints") >= 1)
        {
            PlayerPrefs.SetFloat("mana", PlayerPrefs.GetFloat("mana") + 10);
            PlayerPrefs.SetInt("skillPoints", PlayerPrefs.GetInt("skillPoints") - 1);
            PlayerPrefs.Save();
        }
    }

    //dmg
    public void damageUpgrade()
    {
        if (PlayerPrefs.GetInt("skillPoints") >= 1)
        {
            PlayerPrefs.SetFloat("wandDamage", PlayerPrefs.GetFloat("wandDamage") + 5);
            PlayerPrefs.SetInt("skillPoints", PlayerPrefs.GetInt("skillPoints") - 1);
            PlayerPrefs.Save();
        }
    }

    //AtkSpd
    public void attackSpeedUpgrade()
    {
        if (PlayerPrefs.GetFloat("attackSpeed") > 0.4)
        {
            if (PlayerPrefs.GetInt("skillPoints") >= 1)
            {
                PlayerPrefs.SetFloat("attackSpeed", PlayerPrefs.GetFloat("attackSpeed") - 0.2f);
                PlayerPrefs.SetFloat("atkSpdCount", PlayerPrefs.GetFloat("atkSpdCount") + 1);
                PlayerPrefs.SetInt("skillPoints", PlayerPrefs.GetInt("skillPoints") - 1);
                PlayerPrefs.Save();
            }
        }
    } 

    //Mana Regen
    public void healthRegenUpgrade()
    {
        if (PlayerPrefs.GetFloat("healthRegen") < 5)
        {
            if (PlayerPrefs.GetInt("skillPoints") >= 1)
            {
                PlayerPrefs.SetFloat("healthRegen", PlayerPrefs.GetFloat("healthRegen") + 1);
                PlayerPrefs.SetInt("skillPoints", PlayerPrefs.GetInt("skillPoints") - 1);
                PlayerPrefs.Save();
            }
        }
    }

    //Health Regen
    public void manaRegenUpgrade()
    {
        if (PlayerPrefs.GetFloat("manaRegen") < 5)
        {
            if (PlayerPrefs.GetInt("skillPoints") >= 1)
            {
                PlayerPrefs.SetFloat("manaRegen", PlayerPrefs.GetFloat("manaRegen") + 1);
                PlayerPrefs.SetInt("skillPoints", PlayerPrefs.GetInt("skillPoints") - 1);
                PlayerPrefs.Save();
            }
        }
    }

    public void upgradeClose()
    {
        upgrade.SetActive(false);
    }

}
