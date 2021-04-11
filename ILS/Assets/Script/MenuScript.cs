using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MenuScript : MonoBehaviour
{
    public GameObject tutorial;
    public GameObject helpMenu;
    public GameObject optionMenu;
    public GameObject okAnnBtn;
    [Space]
    [Header("SOUNDS")]
    [SerializeField]private Slider musicSlider;
    [SerializeField]private Slider SFXslider;
    public TextMeshProUGUI musicCount;
    public TextMeshProUGUI sfxCounts;
    private float musicVal;
    private float sfxVal;
    [Space]
    [Header("Toggles")]
    public Toggle shake;
    public Toggle cheat;
    public Toggle damageIndic;
    public Toggle manaPots;
    public Toggle hpPots;
    public Toggle dmg;

    private void Start()
    {
        musicSlider.value = PlayerPrefs.GetFloat("musicValue");
        SFXslider.value = PlayerPrefs.GetFloat("sfxValue");

        if (SceneManager.GetActiveScene().name == "Main Menu")
        {
            okAnnBtn.SetActive(true);
        }

        if(PlayerPrefs.GetInt("isCheat") == 1)
        {
            cheat.isOn = false;
        }
        if (PlayerPrefs.GetInt("isDamageInd") == 1)
        {
            damageIndic.isOn = false;
        }
        if (PlayerPrefs.GetInt("isMana") == 1)
        {
            manaPots.isOn = false;
        }
        if (PlayerPrefs.GetInt("isHealth") == 1)
        {
            hpPots.isOn = false;
        }
        if (PlayerPrefs.GetInt("isShake") == 1)
        {
            shake.isOn = false;
        }
        if (PlayerPrefs.GetInt("isDamage") == 1)
        {
            dmg.isOn = false;
        }

    }

    private void Update()
    {
        musicVal = musicSlider.value;
        sfxVal = SFXslider.value;

        PlayerPrefs.SetFloat("musicValue", musicVal);
        PlayerPrefs.SetFloat("sfxValue", sfxVal);

        musicCount.text = "" + Mathf.FloorToInt(musicVal);
        sfxCounts.text = "" + Mathf.FloorToInt(sfxVal);

        //toggle
        if (shake.isOn == false)
        {
            PlayerPrefs.SetInt("isShake", 1);
            print("shake is off");
        }
        else
        {
            PlayerPrefs.SetInt("isShake", 0);
        }
        if(damageIndic.isOn == false)
        {
            PlayerPrefs.SetInt("isDamageInd", 1);
            print("damage indicator is off");
        }
        else
        {
            PlayerPrefs.SetInt("isDamageInd", 0);
        }
        if (cheat.isOn == false)
        {
            PlayerPrefs.SetInt("isCheat", 1);
            print("cheat is off");
        }
        else
        {
            PlayerPrefs.SetInt("isCheat", 0);
        }
        if (dmg.isOn == false)
        {
            PlayerPrefs.SetInt("isDamage", 1);
            print("dmg is off");
        }
        else
        {
            PlayerPrefs.SetInt("isDamage", 0);
        }
        if (manaPots.isOn == false)
        {
            PlayerPrefs.SetInt("isMana", 1);
            print("mana is off");
        }
        else
        {
            PlayerPrefs.SetInt("isMana", 0);
        }
        if (hpPots.isOn == false)
        {
            PlayerPrefs.SetInt("isHealth", 1);
            print("hp is off");
        }
        else
        {
            PlayerPrefs.SetInt("isHealth", 0);
        }
        PlayerPrefs.Save();
    }
    public void startMenu()
    {
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<Transition>().loadTransition("Base");
        sfxMenu();
    }

    public void _helpMenu()
    {
        helpMenu.SetActive(true);
        sfxMenu();
    }

    public void _TutorialMenu()
    {
        tutorial.SetActive(true);
        sfxMenu();
    }

    public void _optionMenu()
    {
        optionMenu.SetActive(true);
        sfxMenu();
    }

    public void _exitMenu()
    {
        sfxMenu();
        Application.Quit();
    }

    //Close Btn

    public void _closeHelpMenu()
    {
        helpMenu.SetActive(false);
        sfxMenu();
    }

    public void _noTutorialMenu()
    {
       tutorial.SetActive(false);
        sfxMenu();
    }

    public void _yesTutorialMenu()
    {
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<Transition>().loadTransition("TutorialScene");
        sfxMenu();
    }

    public void _closeOptionMenu()
    {
        optionMenu.SetActive(false);
        PlayerPrefs.Save();
        sfxMenu();
    }

    public void okAnnouncement()
    {
        sfxMenu();
        Destroy(okAnnBtn);
    }
    void sfxMenu()
    {
        this.GetComponent<menuSFX>().menuSound();
    }
}
