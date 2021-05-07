using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    //important
    [Header("Important")]
    public GameObject questObj;

    //quest
    [Header("QUEST COUNT")]
    public TextMeshProUGUI mobKillCount;
    public TextMeshProUGUI coinsCollected;
    public TextMeshProUGUI PotionUsed;
    public TextMeshProUGUI TPskillCount;
    public TextMeshProUGUI EnergyBallCount;
    public TextMeshProUGUI fireballCount;
    public TextMeshProUGUI bossKillCount;
    public TextMeshProUGUI deathCount;

    //btn for interaction
    [Header("BUTTON QUEST")]
    public Button mobKillCountBtn;
    public Button coinsCollectedBtn;
    public Button PotionUsedBtn;
    public Button TPskillCountBtn;
    public Button EnergyBallCountBtn;
    public Button fireballCountBtn;
    public Button bossKillCountBtn;
    public Button deathCountBtn;

    //stats
    [Header("STATS COUNT")]
    public TextMeshProUGUI mobKillCountStat;
    public TextMeshProUGUI coinsCollectedStat;
    public TextMeshProUGUI PotionUsedStat;
    public TextMeshProUGUI TPskillCountStat;
    public TextMeshProUGUI EnergyBallCountStat;
    public TextMeshProUGUI fireballCountStat;
    public TextMeshProUGUI bossKillCountStat;
    public TextMeshProUGUI deathCountStat;

    private void Update()
    {
        questCount();
        statCount();
    }

    private void questCount()
    {
        //mob kill
        if(PlayerPrefs.GetInt("mobKilled") >= 50)
        {
            mobKillCount.text = "50 / 50";
        }
        else
        {
            mobKillCount.text = "" + PlayerPrefs.GetInt("mobKilled") + " / 50";
        }

        //coins collected
        if(PlayerPrefs.GetInt("coinsCollected") >= 50)
        {
            mobKillCount.text = "100 / 100";
        }
        else
        {
            mobKillCount.text = "" + PlayerPrefs.GetInt("coinsCollected") + " / 100";
        }

        //potion used
        if(PlayerPrefs.GetInt("potionUsed") >= 10)
        {
            mobKillCount.text = "10 / 10";
        }
        else
        {
            mobKillCount.text = "" + PlayerPrefs.GetInt("potionUsed") + " / 10";
        }

        //tp used
        if(PlayerPrefs.GetInt("tpUsed") >= 10)
        {
            mobKillCount.text = "10 / 10";
        }
        else
        {
            mobKillCount.text = "" + PlayerPrefs.GetInt("tpUsed") + " / 10";
        }

        //energy ball used
        if(PlayerPrefs.GetInt("energyBallUsed") >= 10)
        {
            mobKillCount.text = "10 / 10";
        }
        else
        {
            mobKillCount.text = "" + PlayerPrefs.GetInt("energyBallUsed") + " / 10";
        }

        //fireball shoot used
        if(PlayerPrefs.GetInt("fireballCount") >= 100)
        {
            mobKillCount.text = "100 / 100";
        }
        else
        {
            mobKillCount.text = "" + PlayerPrefs.GetInt("fireballCount") + " / 100";
        }

        //boss kill count
        if(PlayerPrefs.GetInt("bossKilled") >= 5)
        {
            mobKillCount.text = "5 / 5";
        }
        else
        {
            mobKillCount.text = "" + PlayerPrefs.GetInt("bossKilled") + " / 5";
        }

        //death count
        if(PlayerPrefs.GetInt("deathCount") >= 5)
        {
            mobKillCount.text = "5 / 5";
        }
        else
        {
            mobKillCount.text = "" + PlayerPrefs.GetInt("deathCount") + " / 5";
        }
    }
    private void statCount()
    {
        mobKillCountStat.text = "" + PlayerPrefs.GetInt("mobKilled");
        coinsCollectedStat.text = "" + PlayerPrefs.GetInt("coinsCollected");
        PotionUsedStat.text = "" + PlayerPrefs.GetInt("potionUsed");
        TPskillCountStat.text = "" + PlayerPrefs.GetInt("tpUsed");
        EnergyBallCountStat.text = "" + PlayerPrefs.GetInt("energyBallUsed");
        fireballCountStat.text = "" + PlayerPrefs.GetInt("fireballCount");
        bossKillCountStat.text = "" + PlayerPrefs.GetInt("bossKilled");
        deathCountStat.text = "" + PlayerPrefs.GetInt("deathCount");
    }

    public void _closeQuest()
    {
        questObj.SetActive(false);
    }
}
