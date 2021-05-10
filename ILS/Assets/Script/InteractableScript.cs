using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InteractableScript : MonoBehaviour
{
    [Header("ETC")]
    [SerializeField] private Transform player;
    [SerializeField] private GameObject interactBtn;
    [SerializeField] private Image txtInteractable;
    public bool isInteractScene = true;

    //Market
    [Header("MARKET")]
    public GameObject marketPopup;
    public float minDisMarket = 5f;
    [SerializeField] private Transform market;

    //Magic
    [Header("MAGIC")]
    public GameObject magicUpgrade;
    public float minDisMagic = 5f;
    [SerializeField] private Transform magic;

    //CAVE
    [Header("Cave")]
    public float minDisCave = 5f;
    public GameObject caveObj;
    [SerializeField] private Transform cave;

    //Quest
    [Header("Quest")]
    public float minDisQuest = 5f;
    public GameObject questObj;
    [SerializeField] private Transform quest;

    //Gamemode
    [Header("Gamemode")]
    public float minDisGamemode = 5f;
    public GameObject gamemodeObj;
    [SerializeField] private Transform gamemode;

    //other
    private int countBtn = 0;
    [Space]
    public TextMeshProUGUI fps;
    private float current;


    void Update()
    {
        if (isInteractScene == true)
        {
           float marketDist = Vector3.Distance(market.position, player.position);
           float magicDist = Vector3.Distance(magic.position, player.position);
           float caveDist = Vector3.Distance(cave.position, player.position);
           float questDist = Vector3.Distance(quest.position, player.position);
           float gamemodeDist = Vector3.Distance(gamemode.position, player.position);

            if (marketDist <= minDisMarket)
            {
                interactBtn.GetComponent<Image>().color = Color.white;
                txtInteractable.color = Color.white;
                countBtn = 1;
            }
            else if(magicDist <= minDisMagic)
            {
                interactBtn.GetComponent<Image>().color = Color.white;
                txtInteractable.color = Color.white;
                countBtn = 2;
            }
            else if(caveDist <= minDisCave)
            {
                interactBtn.GetComponent<Image>().color = Color.white;
                txtInteractable.color = Color.white;
                countBtn = 3;
            }
            else if(questDist <= minDisQuest)
            {
                interactBtn.GetComponent<Image>().color = Color.white;
                txtInteractable.color = Color.white;
                countBtn = 4;
            }
            else if(gamemodeDist <= minDisGamemode)
            {
                interactBtn.GetComponent<Image>().color = Color.white;
                txtInteractable.color = Color.white;
                countBtn = 5;
            }
            else
            {
                interactBtn.GetComponent<Image>().color = Color.black;
                txtInteractable.color = Color.black;
                countBtn = 0;
            }
        }
    }

    public void interactable()
    {
        if (countBtn == 1)
        {
            showMarketUI();
        }
        else if (countBtn == 2)
        {
            showMagicUI();
        }
        else if (countBtn == 3)
        {
            showCaveUI();
        }
        else if (countBtn == 4)
        {
            openQuest();
        }
        else if (countBtn == 5)
        {
            openGamemode();
        }
    }

    public void openQuest()
    {
        questObj.SetActive(true);
    }

    public void openGamemode()
    {
        gamemodeObj.SetActive(true);
    }

    public void showMarketUI()
    {
        marketPopup.SetActive(true);
    }

    public void showCaveUI()
    {
        caveObj.SetActive(true);
    }

    public void showMagicUI()
    {
        magicUpgrade.SetActive(true);
    }

    public void marketClose()
    {
        menuSFX();
        marketPopup.SetActive(false);
    }

    public void closeStage()
    {
        menuSFX();
        caveObj.SetActive(false);
    }
    void menuSFX()
    {
        GameObject.FindGameObjectWithTag("MenuSfx").GetComponent<menuSFX>().menuSound();
    }
}
