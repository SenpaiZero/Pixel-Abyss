using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float enemyHP = 10;

    [SerializeField] private bool lilMelee = false;
    [SerializeField] private bool lilRange = false;
    [SerializeField] private bool boar = false;
    [SerializeField] private bool scorpion = false;
    [SerializeField] private bool skeleton = false;
    [SerializeField] private bool bat = false;
    [SerializeField] private bool fireTotem = false;
    [SerializeField] private bool flyingMelee = false;
    private Animator hitAnim;

    [Header("boss")]
    public bool isBoss = false;
    [SerializeField] private bool isStage5Boss = false;
    public TextMeshProUGUI bossHPtxt;
    public Image bossHPimg;
    private float bossMaxHP;


    [Header("etc")]
    public GameObject dmgTextObj;
    public Transform textPos;
    [SerializeField] private GameObject coins;

    public static List<Enemy> enemyList = new List<Enemy>();

    public static List<Enemy> GetEnemyList()
    {
        return enemyList;
    }


    private void Awake()
    {
        enemyList.Add(this);
    }

    private void Start()
    {
        if (!isBoss)
        {
            hitAnim = GetComponent<Animator>();
        }
        if (isBoss)
        {
            bossMaxHP = enemyHP;
            hitAnim = GetComponentInChildren<Animator>();
        }
    }

    private void Update()
    {
        if (isBoss)
        {
            bossHPimg.fillAmount = enemyHP / bossMaxHP;
            bossHPtxt.text = "" + enemyHP.ToString("0") + " / " + bossMaxHP;
        }
    }



    public void takeDamage(float ammount, bool isCrit)
    {
        enemyHP -= ammount;
        hitAnim.Play("hit");
        if (PlayerPrefs.GetInt("isDamage") == 0)
        {
            if (isCrit == false)
            {
                GameObject clone = Instantiate(dmgTextObj, textPos.position, Quaternion.identity);
                clone.GetComponentInChildren<TextMeshPro>().text = "" + ammount.ToString("F0");
                clone.transform.parent = transform.parent;
                Destroy(clone, 3f);
                Debug.Log("Text Enemy Damage Instantiated");
            }
            else
            {
                GameObject clone = Instantiate(dmgTextObj, textPos.position, Quaternion.identity);
                clone.GetComponentInChildren<TextMeshPro>().text = "CRIT!! \n" + ammount.ToString("F0");
                clone.transform.parent = transform.parent;
                clone.GetComponentInChildren<TextMeshPro>().color = Color.red;
                Destroy(clone, 3f);
                Debug.Log("Text Enemy crit Instantiated");
            }
        }


        if(enemyHP <= 0)
        {
            Debug.Log("Enemy ded");
            enemyDead();
        }
    }

    void enemyDead()
    {
        if (isBoss == false)
        {
            getManaPerKill();
            getHealthPerKill();
            StartCoroutine(speedPerKill());
            GameObject clone = Instantiate(coins, transform.position, Quaternion.identity);
            Destroy(clone, 20f);
            exp();
            enemyList.Remove(this);
            this.GetComponent<SpriteRenderer>().enabled = false;
            this.GetComponent<Collider2D>().enabled = false;
            Destroy(gameObject, 3f);

        }
        else
        {
            enemyList.Remove(this);
            Destroy(gameObject);
            exp();
            //instantiate treasure chest
        }

    }

    void getManaPerKill()
    {
        if(PlayerPrefs.GetString("manaPerKill") == "true")
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().playerRestoreMana(5);
        }
    }

    void getHealthPerKill()
    {
        if(PlayerPrefs.GetString("HPperKill") == "true")
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().playerRestoreHP(5);
        }
    }

    IEnumerator speedPerKill()
    {
        PlayerPrefs.SetFloat("killSpeedBonus", 1.2f);
        yield return new WaitForSeconds(2f);
        PlayerPrefs.SetFloat("killSpeedBonus", 1f);
    }

    void exp()
    {
        if (skeleton == true)
        {
            getExp(10);
        }
        else if(boar == true)
        {
            getExp(10);
        }
        else if(lilMelee == true)
        {
            getExp(10);
        }
        else if(bat == true)
        {
            getExp(13);
        }
        else if(flyingMelee == true)
        {
            getExp(23);
        }
        else if(lilRange == true)
        {
            getExp(15);
        }
        else if(lilRange == true)
        {
            getExp(20);
        }
        else if(scorpion == true)
        {
            getExp(30);
        }
        else if(isStage5Boss == true)
        {
            getExp(200);
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
            PlayerPrefs.SetFloat("ExpToLevelUp", PlayerPrefs.GetFloat("ExpToLevelUp") + (PlayerPrefs.GetFloat("ExpToLevelUp") / 7));
            PlayerPrefs.Save();
            Debug.Log("Level: " + PlayerPrefs.GetInt("Level"));
        }
    }

    private void getExp(float exp)
    {
        exp = (exp * PlayerPrefs.GetInt("doubleDrop"));
        PlayerPrefs.SetFloat("EXP", PlayerPrefs.GetFloat("EXP") + (exp * PlayerPrefs.GetFloat("extraEXP")));
        PlayerPrefs.Save();
    }

}
