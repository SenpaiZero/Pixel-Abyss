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

    [Header("BTN IMG QUEST")]
    public Image mobKillCountImg;
    public Image coinsCollectedImg;
    public Image PotionUsedImg;
    public Image TPskillCountImg;
    public Image EnergyBallCountImg;
    public Image fireballCountImg;
    public Image bossKillCountImg;
    public Image deathCountImg;

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
        claimButton();
    }

    private void questCount()
    {
        //mob kill
        if(PlayerPrefs.GetInt("mobsKilled") >= 50)
        {
            mobKillCount.text = "50 / 50";
        }
        else
        {
            mobKillCount.text = "" + PlayerPrefs.GetInt("mobsKilled") + " / 50";
        }

        //coins collected
        if(PlayerPrefs.GetInt("coinsCollected") >= 50)
        {
            coinsCollected.text = "100 / 100";
        }
        else
        {
            coinsCollected.text = "" + PlayerPrefs.GetInt("coinsCollected") + " / 100";
        }

        //potion used
        if(PlayerPrefs.GetInt("potionUsed") >= 10)
        {
            PotionUsed.text = "10 / 10";
        }
        else
        {
            PotionUsed.text = "" + PlayerPrefs.GetInt("potionUsed") + " / 10";
        }

        //tp used
        if(PlayerPrefs.GetInt("tpUsed") >= 10)
        {
            TPskillCount.text = "10 / 10";
        }
        else
        {
            TPskillCount.text = "" + PlayerPrefs.GetInt("tpUsed") + " / 10";
        }

        //energy ball used
        if(PlayerPrefs.GetInt("energyBallUsed") >= 10)
        {
            EnergyBallCount.text = "10 / 10";
        }
        else
        {
            EnergyBallCount.text = "" + PlayerPrefs.GetInt("energyBallUsed") + " / 10";
        }

        //fireball shoot used
        if(PlayerPrefs.GetInt("fireballCount") >= 100)
        {
            fireballCount.text = "100 / 100";
        }
        else
        {
            fireballCount.text = "" + PlayerPrefs.GetInt("fireballCount") + " / 100";
        }

        //boss kill count
        if(PlayerPrefs.GetInt("bossKilled") >= 5)
        {
            bossKillCount.text = "5 / 5";
        }
        else
        {
            bossKillCount.text = "" + PlayerPrefs.GetInt("bossKilled") + " / 5";
        }

        //death count
        if(PlayerPrefs.GetInt("deathCount") >= 5)
        {
            deathCount.text = "5 / 5";
        }
        else
        {
            deathCount.text = "" + PlayerPrefs.GetInt("deathCount") + " / 5";
        }
    }
    private void statCount()
    {
        mobKillCountStat.text = "" + PlayerPrefs.GetInt("mobsKilled");
        coinsCollectedStat.text = "" + PlayerPrefs.GetInt("coinsCollected");
        PotionUsedStat.text = "" + PlayerPrefs.GetInt("potionUsed");
        TPskillCountStat.text = "" + PlayerPrefs.GetInt("tpUsed");
        EnergyBallCountStat.text = "" + PlayerPrefs.GetInt("energyBallUsed");
        fireballCountStat.text = "" + PlayerPrefs.GetInt("fireballCount");
        bossKillCountStat.text = "" + PlayerPrefs.GetInt("bossKilled");
        deathCountStat.text = "" + PlayerPrefs.GetInt("deathCount");
    }

    private void claimButton()
    {
        if (PlayerPrefs.GetString("mobKilledDone") == "true")
        {
            mobKillCountBtn.interactable = false;
            mobKillCountImg.color = Color.green;
        }

        if (PlayerPrefs.GetString("coinsCollectedDone") == "true")
        {
            coinsCollectedBtn.interactable = false;
            coinsCollectedImg.color = Color.green;
        }

        if (PlayerPrefs.GetString("potionUsedDone") == "true")
        {
            PotionUsedBtn.interactable = false;
            PotionUsedImg.color = Color.green;
        }

        if (PlayerPrefs.GetString("tpUsedDone") == "true")
        {
            TPskillCountBtn.interactable = false;
            TPskillCountImg.color = Color.green;
        }

        if (PlayerPrefs.GetString("energyBallUsedDone") == "true")
        {
            EnergyBallCountBtn.interactable = false;
            EnergyBallCountImg.color = Color.green;
        }

        if (PlayerPrefs.GetString("fireballCountDone") == "true")
        {
            fireballCountBtn.interactable = false;
            fireballCountImg.color = Color.green;
        }

        if (PlayerPrefs.GetString("bossKilledDone") == "true")
        {
            bossKillCountBtn.interactable = false;
            bossKillCountImg.color = Color.green;
        }

        if (PlayerPrefs.GetString("deathCountDone") == "true")
        {
            deathCountBtn.interactable = false;
            deathCountImg.color = Color.green;
        }
    }

    public void _mobKilledQuest()
    {
        sfxMenu();
        if (PlayerPrefs.GetInt("mobsKilled") >= 50)
        {
            PlayerPrefs.SetString("mobKilledDone", "true");
            reward();
        }
    }

    public void coinsCollectedQuest()
    {
        sfxMenu();
        if (PlayerPrefs.GetInt("coinsCollected") >= 100)
        {
            PlayerPrefs.SetString("coinsCollectedDOne", "true");
            reward();
        }
    }

    public void _potionQuest()
    {
        sfxMenu();
        if (PlayerPrefs.GetInt("potionUsed") >= 10)
        {
            PlayerPrefs.SetString("potionUsedDone", "true");
            reward();
        }
    }

    public void _tpQuest()
    {
        sfxMenu();
        if (PlayerPrefs.GetInt("tpUsed") >= 10)
        {
            PlayerPrefs.SetString("tpUsedDone", "true");
            reward();
        }
    }

    public void _energyBallQuest()
    {
        sfxMenu();
        sfxMenu();
        if (PlayerPrefs.GetInt("energyBallUsed") >= 10)
        {
            PlayerPrefs.SetString("energyBallUsedDone", "true");
            reward();
        }
    }

    public void _fireballQuest()
    {
        sfxMenu();
        if (PlayerPrefs.GetInt("fireballCount") >= 100)
        {
            PlayerPrefs.SetString("fireballCountDone", "true");
            reward();
        }
    }

    public void _bossKiledQuest()
    {
        sfxMenu();
        if (PlayerPrefs.GetInt("bossKilled") >= 5)
        {
            PlayerPrefs.SetString("bossKilledDone", "true");
            reward();
        }
    }

    public void _deathsQuest()
    {
        sfxMenu();
        if (PlayerPrefs.GetInt("deathCount") >= 5)
        {
            PlayerPrefs.SetString("deathCountDone", "true");
            reward();
        }
    }

    public void _closeQuest()
    {
        questObj.SetActive(false);
        sfxMenu();
    }

    private void reward()
    {
        PlayerPrefs.SetFloat("EXP", PlayerPrefs.GetFloat("EXP") + 100);
        PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + 100);
        PlayerPrefs.Save();

        if (PlayerPrefs.GetFloat("EXP") >= PlayerPrefs.GetFloat("ExpToLevelUp"))
        {
            //levelup
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().levelUp();

            Debug.Log("LevelUp");
            PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1);
            PlayerPrefs.SetInt("skillPoints", PlayerPrefs.GetInt("skillPoints") + 1);
            PlayerPrefs.Save();
            PlayerPrefs.SetFloat("EXP", 0);
            PlayerPrefs.SetFloat("ExpToLevelUp", PlayerPrefs.GetFloat("ExpToLevelUp") + (PlayerPrefs.GetFloat("ExpToLevelUp") / 7));
            PlayerPrefs.Save();
            Debug.Log("Level: " + PlayerPrefs.GetInt("Level"));
        }
        print("claimed");
    }
    void sfxMenu()
    {
        GameObject.FindGameObjectWithTag("MenuSfx").GetComponent<menuSFX>().menuSound();
    }
}
