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

    //magic Variables
    private float wandDamage = 10f; 
    private float attackSpeed = 1.4f; //1.4 1.2 1.0 0.8 .6 .4
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
            PlayerPrefs.SetFloat("wandDamage", wandDamage);
            PlayerPrefs.SetFloat("attackSpeed", attackSpeed);
            PlayerPrefs.SetFloat("atkSpdCount", attackSpeedCount);
            PlayerPrefs.SetFloat("magicSpeed", magicSpeed);
            PlayerPrefs.SetInt("wandLevel", wandLevel);
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
            PlayerPrefs.Save();

            //saving first run
            PlayerPrefs.SetInt("firstRun", firstRun + 5);
            PlayerPrefs.Save();

        }

    }

}
