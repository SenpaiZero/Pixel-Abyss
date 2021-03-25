using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float enemyHP = 10;
    [SerializeField] private GameObject coins;

    [SerializeField] private bool lilMelee = false;
    [SerializeField] private bool lilRange = false;
    [SerializeField] private bool boar = false;
    [SerializeField] private bool scorpion = false;


    public static List<Enemy> enemyList = new List<Enemy>();

    public static List<Enemy> GetEnemyList()
    {
        return enemyList;
    }

    public GameObject dmgTextObj;
    public Transform textPos;

    private void Awake()
    {
        enemyList.Add(this);
    }

    public void takeDamage(float ammount)
    {
        enemyHP -= ammount;
        if (PlayerPrefs.GetInt("isDamage") == 0)
        {
            GameObject clone = Instantiate(dmgTextObj, textPos.position, Quaternion.identity);
            clone.GetComponentInChildren<TextMeshPro>().text = "" + ammount.ToString("F0");
            clone.transform.parent = transform.parent;
            Destroy(clone, 3f);
            Debug.Log("Text Enemy Damage Instantiated");
        }


        if(enemyHP <= 0)
        {
            Debug.Log("Enemy ded");
            enemyDead();
        }
    }

    void enemyDead()
    {
        GameObject clone = Instantiate(coins, transform.position, Quaternion.identity);
        Destroy(clone, 20f);
        exp();
        enemyList.Remove(this);
        Destroy(gameObject);

    }

    void exp()
    {
        if(boar == true)
        {
            PlayerPrefs.SetFloat("EXP", PlayerPrefs.GetFloat("EXP") + 5);
            PlayerPrefs.Save();
        }
        else if(lilMelee == true)
        {
            PlayerPrefs.SetFloat("EXP", PlayerPrefs.GetFloat("EXP") + 10);
            PlayerPrefs.Save();
        }
        else if(lilRange == true)
        {
            PlayerPrefs.SetFloat("EXP", PlayerPrefs.GetFloat("EXP") + 15);
            PlayerPrefs.Save();
        }
        else if(scorpion == true)
        {
            PlayerPrefs.SetFloat("EXP", PlayerPrefs.GetFloat("EXP") + 20);
            PlayerPrefs.Save();
        }
        Debug.Log("Player exp: " + PlayerPrefs.GetFloat("EXP"));

        if(PlayerPrefs.GetFloat("EXP") >= PlayerPrefs.GetFloat("ExpToLevelUp"))
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().levelUp();
            //levelup
            Debug.Log("LevelUp");
            PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1);
            PlayerPrefs.SetInt("skillPoints", PlayerPrefs.GetInt("skillPoints") + 1);
            PlayerPrefs.Save();
            PlayerPrefs.SetFloat("EXP", 0);
            PlayerPrefs.SetFloat("ExpToLevelUp", PlayerPrefs.GetFloat("ExpToLevelUp") + (PlayerPrefs.GetFloat("ExpToLevelUp") / 2));
            PlayerPrefs.Save();
            Debug.Log("Level: " + PlayerPrefs.GetInt("Level"));
        }
    }

}
