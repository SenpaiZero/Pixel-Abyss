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
            stageNum();

        }
    }

    public void stageBtn()
    {
        trans.GetComponent<Transition>().loadTransition("Stage " + stageNumber);
        GameObject.FindGameObjectWithTag("MenuSfx").GetComponent<menuSFX>().menuSound();
    }

    private void stageNum()
    {
        if (PlayerPrefs.GetInt("stage 2") == 1)
        {
            stage2.interactable = true;
        }
        if (PlayerPrefs.GetInt("stage 3") == 1)
        {
            stage3.interactable = true;
        }
        if (PlayerPrefs.GetInt("stage 4") == 1)
        {
            stage4.interactable = true;
        }
        if (PlayerPrefs.GetInt("stage 5") == 1)
        {
            stage5.interactable = true;
        }
    }

}
