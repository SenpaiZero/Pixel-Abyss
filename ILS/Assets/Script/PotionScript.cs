using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PotionScript : MonoBehaviour
{
    public Image hpImg;
    public Image mpImg;
    public TextMeshProUGUI hpTxt;
    public TextMeshProUGUI mpTxt;

    private GameObject player;
    private bool isCD_HP = false;
    private bool isCD_MP = false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        hpTxt.text = "" + PlayerPrefs.GetInt("hpPots");
        mpTxt.text = "" + PlayerPrefs.GetInt("manaPots");
    }

    public void hpPots()
    {
        if (PlayerPrefs.GetString("infinitePots") == "false")
        {
            if (isCD_HP == false && PlayerPrefs.GetInt("hpPots") >= 1)
            {
                StartCoroutine("hpPots_");
            }
        }
        else if(isCD_HP == false)
        {
            StartCoroutine("hpPots_");
        }
    }

    public void mpPots()
    {
        if (PlayerPrefs.GetString("infinitePots") == "false")
        {
            if (isCD_MP == false && PlayerPrefs.GetInt("manaPots") >= 1)
            {
                StartCoroutine("manaPots_");
            }
        }
        else if (isCD_MP == false)
        {
            StartCoroutine("manaPots_");
        }
    }

    IEnumerator hpPots_()
    {
        if (PlayerPrefs.GetString("infinitePots") == "false")
        {
            isCD_HP = true;
            PlayerPrefs.SetInt("hpPots", PlayerPrefs.GetInt("hpPots") - 1);
            PlayerPrefs.Save();
            player.GetComponent<Player>().playerRestoreHP(20 * PlayerPrefs.GetFloat("doublePots"));
            hpImg.color = Color.black;
            yield return new WaitForSeconds(2f);
            hpImg.color = Color.white;
            isCD_HP = false;
        }
        else
        {
            isCD_HP = true;
            player.GetComponent<Player>().playerRestoreHP(20 * PlayerPrefs.GetFloat("doublePots"));
            hpImg.color = Color.black;
            yield return new WaitForSeconds(6f);
            hpImg.color = Color.white;
            isCD_HP = false;
        }
    }
    
    IEnumerator manaPots_()
    {
        if (PlayerPrefs.GetString("infinitePots") == "false")
        {
            isCD_MP = true;
            PlayerPrefs.SetInt("manaPots", PlayerPrefs.GetInt("manaPots") - 1);
            PlayerPrefs.Save();
            player.GetComponent<Player>().playerRestoreMana(20 * PlayerPrefs.GetFloat("doublePots"));
            mpImg.color = Color.black;
            yield return new WaitForSeconds(2f);
            mpImg.color = Color.white;
            isCD_MP = false;
        }
        else
        {
            isCD_MP = true;
            player.GetComponent<Player>().playerRestoreMana(20 * PlayerPrefs.GetFloat("doublePots"));
            mpImg.color = Color.black;
            yield return new WaitForSeconds(6f);
            mpImg.color = Color.white;
            isCD_MP = false;
        }
        
    }
}

