using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariablesScript : MonoBehaviour
{
    //Player
    private float health = 50f;
    private float mana = 50f;
    private float healthRegen = 1f;
    private float manaRegen = 1f;
    private float criticalChance = 5f;
    private float cooldownReduc = 0f;

    //magic Variables
    private float wandDamage = 10f; 
    private float attackSpeed = 0.5f; //1.0 
    private float attackSpeedCount = 1f;
    private float magicSpeed = 10;
    private int wandLevel = 1; //kung ilan lalaban sa fireball

    //EXP 
    private int level = 1;
    private float exp = 0f;
    private float expToLvlUp = 100f;
    private int skillPoint = 0;

    //POTS
    private int ManaPots;
    private int HpPots;

    //Others
    private int coins = 0;
    private float movementSpeed = 6f;
    private int firstRun = 0;

    //upgrade
    private int powerLevel = 0;
    private int vitalityLevel = 0;
    private int magicLevel = 0;
    private int hasteLevel = 0;
    private int greedLevel = 0;

    void Awake()
    {
        firstRun = PlayerPrefs.GetInt("firstRun");
        if(firstRun <= 0)
        {
        //player
            PlayerPrefs.SetFloat("health", health);
            PlayerPrefs.SetFloat("healthRegen", healthRegen);
            PlayerPrefs.SetFloat("manaRegen", manaRegen);
            PlayerPrefs.SetFloat("mana", mana);
            PlayerPrefs.Save();

            //Wand
            PlayerPrefs.SetFloat("critChance", criticalChance);
            PlayerPrefs.SetFloat("wandDamage", wandDamage);
            PlayerPrefs.SetFloat("attackSpeed", attackSpeed);
            PlayerPrefs.SetFloat("atkSpdCount", attackSpeedCount);
            PlayerPrefs.SetFloat("magicSpeed", magicSpeed);
            PlayerPrefs.SetInt("wandLevel", wandLevel);
            PlayerPrefs.SetFloat("cdr", cooldownReduc);
            PlayerPrefs.SetInt("attackSpeedCounter", 0);
            PlayerPrefs.SetInt("movementSpeedCounter", 0);
            PlayerPrefs.Save();


            //other
            PlayerPrefs.SetFloat("movementSpeed", movementSpeed);
            PlayerPrefs.SetFloat("EXP", exp);
            PlayerPrefs.SetFloat("ExpToLevelUp", expToLvlUp);
            PlayerPrefs.SetInt("Level", level);
            PlayerPrefs.SetInt("skillPoints", skillPoint);
            PlayerPrefs.SetInt("Coins", coins);
            PlayerPrefs.Save();

            PlayerPrefs.SetInt("hpPots", HpPots);
            PlayerPrefs.SetInt("manaPots", ManaPots);

            PlayerPrefs.SetInt("extraCoins", 1);
            PlayerPrefs.SetFloat("extraEXP", 1);

            PlayerPrefs.SetInt("stage 1", 0);
            PlayerPrefs.SetInt("stage 2", 0);
            PlayerPrefs.SetInt("stage 3", 0);
            PlayerPrefs.SetInt("stage 4", 0);
            PlayerPrefs.SetInt("stage 5", 0);

            PlayerPrefs.Save();

            //MENU
            PlayerPrefs.SetInt("isDamageInd", 0);
            PlayerPrefs.SetInt("isCheat", 0);
            PlayerPrefs.SetInt("isShake", 0);
            PlayerPrefs.SetInt("isMana", 0);
            PlayerPrefs.SetInt("isHealth", 0);
            PlayerPrefs.SetInt("isDamage", 0);

            PlayerPrefs.SetFloat("musicValue", 50);
            PlayerPrefs.SetFloat("sfxValue", 50);

            //skill
            PlayerPrefs.SetInt("powerLevel", powerLevel);
            PlayerPrefs.SetInt("magicLevel", magicLevel);
            PlayerPrefs.SetInt("hasteLevel", hasteLevel);
            PlayerPrefs.SetInt("vitalityLevel", vitalityLevel);
            PlayerPrefs.SetInt("greedLevel", greedLevel);

            //powerlevel
            PlayerPrefs.SetFloat("critChanceMul", 1);
            PlayerPrefs.SetInt("critDamage", 2);

            //magic level
            PlayerPrefs.SetInt("50ManaPercent", 1);
            PlayerPrefs.SetFloat("doublePots", 1);

            //saving first run
            PlayerPrefs.SetInt("firstRun", firstRun + 5);
            PlayerPrefs.Save();

        }

    }

}
