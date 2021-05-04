using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class helpScript : MonoBehaviour
{
    public GameObject defaltText;
    public GameObject controlObj;
    public GameObject skillsObj;
    public GameObject npcObj;
    public GameObject enemiesObj;
    public GameObject faqsObj;

    public void closeHelp()
    {
        sfxMenu();
        defaltText.SetActive(true);
        controlObj.SetActive(false);
        skillsObj.SetActive(false);
        npcObj.SetActive(false);
        enemiesObj.SetActive(false);
        faqsObj.SetActive(false);
        this.gameObject.SetActive(false);
    }

    public void controlText()
    {
        sfxMenu();
        defaltText.SetActive(false);
        controlObj.SetActive(true);
        skillsObj.SetActive(false);
        npcObj.SetActive(false);
        enemiesObj.SetActive(false);
        faqsObj.SetActive(false);

    }

    public void skillTest()
    {
        sfxMenu();
        defaltText.SetActive(false);
        controlObj.SetActive(false);
        skillsObj.SetActive(true);
        npcObj.SetActive(false);
        enemiesObj.SetActive(false);
        faqsObj.SetActive(false);
    }

    public void npcText()
    {
        sfxMenu();
        defaltText.SetActive(false);
        controlObj.SetActive(false);
        skillsObj.SetActive(false);
        npcObj.SetActive(true);
        enemiesObj.SetActive(false);
        faqsObj.SetActive(false);
    }

    public void enemiesText()
    {
        sfxMenu();
        defaltText.SetActive(false);
        controlObj.SetActive(false);
        skillsObj.SetActive(false);
        npcObj.SetActive(false);
        enemiesObj.SetActive(true);
        faqsObj.SetActive(false);
    }

    public void faqsText()
    {
        sfxMenu();
        defaltText.SetActive(false);
        controlObj.SetActive(false);
        skillsObj.SetActive(false);
        npcObj.SetActive(false);
        enemiesObj.SetActive(false);
        faqsObj.SetActive(true);
    }
    void sfxMenu()
    {
        this.GetComponent<menuSFX>().menuSound();
    }

    public void linkFunc()
    {
        sfxMenu();
        Application.OpenURL("https://github.com/SenpaiZero/Pixel-Abyss");
    }
}
