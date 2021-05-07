using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuickMenu : MonoBehaviour
{
    //instantiate
    [SerializeField] private GameObject stage;
    [SerializeField] private GameObject upgrade;
    [SerializeField] private GameObject market;
    [SerializeField] private GameObject gamemode;
    [SerializeField] private GameObject quest;

    //Button
    [Space]
    [SerializeField] private Image mainBtn;
    [SerializeField] private GameObject stageBtn;
    [SerializeField] private GameObject upgradeBtn;
    [SerializeField] private GameObject marketBtn;
    [SerializeField] private GameObject gamemodeBtn;
    [SerializeField] private GameObject questBtn;

    private bool isOpen = false;

    public void quickMenuClick()
    {
        sfxMenu();
        if (isOpen == false)
        {
            isOpen = true;
            StartCoroutine(menuAnimOpen());
        }
        else
        {
            isOpen = false;
            StartCoroutine(menuAnimClose());
        }
    }

    public void openQuest()
    {
        sfxMenu();
        quest.SetActive(true);
    }
    public void openStage()
    {
        sfxMenu();
        stage.SetActive(true);
    }

    public void openMarket()
    {
        sfxMenu();
        market.SetActive(true);
    }

    public void openUpgrade()
    {
        sfxMenu();
        upgrade.SetActive(true);
    }
    void sfxMenu()
    {
        this.GetComponent<menuSFX>().menuSound();
    }
    IEnumerator menuAnimOpen()
    {
        stageBtn.SetActive(true);
        yield return new WaitForSeconds(0.02f);

        gamemodeBtn.SetActive(true);
        yield return new WaitForSeconds(0.02f);

        upgradeBtn.SetActive(true);
        yield return new WaitForSeconds(0.02f);

        marketBtn.SetActive(true);
        yield return new WaitForSeconds(0.02f);

        questBtn.SetActive(true);
    }

    IEnumerator menuAnimClose()
    {
        questBtn.SetActive(false);
        yield return new WaitForSeconds(0.02f);

        marketBtn.SetActive(false);
        yield return new WaitForSeconds(0.02f);

        upgradeBtn.SetActive(false);
        yield return new WaitForSeconds(0.02f);

        gamemodeBtn.SetActive(false);
        yield return new WaitForSeconds(0.02f);

        stageBtn.SetActive(false);
    }
}
