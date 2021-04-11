using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndStage : MonoBehaviour
{
    public string sceneName;
    public int nextStageNumber;
    private int currentStage;

    private void Start()
    {
        currentStage = nextStageNumber - 1;
    }

    public void nextStage()
    {
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<Transition>().loadTransition(sceneName);
        sfxMenu();
    }

    public void baseReturn()
    {
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<Transition>().loadTransition("Base");
        sfxMenu();
    }

    void sfxMenu()
    {
        this.GetComponent<menuSFX>().menuSound();
        if (currentStage >= PlayerPrefs.GetInt("StageUnlocked"))
        {
            PlayerPrefs.SetInt("stageUnlocked", nextStageNumber);
        }
    }
}
