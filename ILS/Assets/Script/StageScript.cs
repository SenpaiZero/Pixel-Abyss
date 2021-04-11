using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageScript : MonoBehaviour
{
    public int stageNumber;
    private GameObject trans;

    public bool isManager = false;
    public Button stage1;
    public Button stage2;
    public Button stage3;
    public Button stage4;
    public Button stage5;
    public Button stage6;
    public Button stage7;
    public Button stage8;
    public Button stage9;
    public Button stage10;

    private void Start()
    {
        trans = GameObject.FindGameObjectWithTag("GameManager");
    }

    private void Update()
    {
        if (isManager == true)
        {
            stageNum(PlayerPrefs.GetInt("stageUnlocked"));

        }
    }

    public void stageBtn()
    {
        trans.GetComponent<Transition>().loadTransition("Stage " + stageNumber);
        GameObject.FindGameObjectWithTag("MenuSfx").GetComponent<menuSFX>().menuSound();
    }

    private void stageNum(int stageNum)
    {
        if (stageNum >= 1)
        {
            stage1.interactable = true;
        }
        if (stageNum >= 2)
        {
            stage2.interactable = true;
        }
        if (stageNum >= 3)
        {
            stage3.interactable = true;
        }
        if (stageNum >= 4)
        {
            stage4.interactable = true;
        }
        if (stageNum >= 5)
        {
            stage5.interactable = true;
        }
        if (stageNum >= 6)
        {
            stage6.interactable = true;
        }
        if (stageNum >= 7)
        {
            stage7.interactable = true;
        }
        if (stageNum >= 8)
        {
            stage8.interactable = true;
        }
        if (stageNum >= 9)
        {
            stage9.interactable = true;
        }
        if (stageNum >= 10)
        {
            stage10.interactable = true;
        }
    }

}
