using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    [Header("ETC")]
    [SerializeField] private Transform player;
    [SerializeField] private GameObject interactBtn;
    [SerializeField] private Image txtInteractable;
    public GameObject skeleton;
    public GameObject tutorialObj;
    public TextMeshProUGUI tutorialText;

    //Magic
    [Header("MAGIC")]
    public GameObject magicUpgrade;
    public float minDisMagic = 5f;
    [SerializeField] private Transform magic;
    //other
    private int countBtn = 0;
    private int tutLevel = 1;
    private Vector3 playerBac;
    bool isContinue = false;
    bool isContinue1 = false;
    bool isClose = false;


    private void Start()
    {
        playerBac = player.transform.position;
    }
    private void Update()
    {
        interFunc();
        afterSkeli();

        if (isContinue == false)
        {
            if (playerBac != player.transform.position)
            {
                StartCoroutine(moveTut());
            }
        }

        if(isClose == false)
        {
            tutorialObj.SetActive(true);
        }
        else
        {
            tutorialObj.SetActive(false);
        }

        

        switch(tutLevel)
        {
            case 1:
                tutorialText.text = "Use the joystick on the left side of the screen to move around.";
                break;
            case 2:
                tutorialText.text = "Great! now go to the skeleton and use your skills to kill him. Don't worry he is sleeping";
                break;
            case 3:
                tutorialText.text = "Goodjob! I'm Giving you 5 skill points since you followed my instruction. Use it on the magic circle to level up your skills";
                break;
            case 4:
                tutorialText.text = "Nice! That's all for me. Enjoy your time in this world.";
                break;
        }

    }


    public void interactable()
    {
        if (countBtn == 2)
        {
            showMagicUI();
        }
    }

    public void showMagicUI()
    {
        magicUpgrade.SetActive(true);
    }
    public void magicCloseUI()
    {
        isClose = false;
    }


    private void interFunc()
    {
        float magicDist = Vector3.Distance(magic.position, player.position);

        if (magicDist <= minDisMagic)
        {
            interactBtn.GetComponent<Image>().color = Color.white;
            txtInteractable.color = Color.white;
            countBtn = 2;
        }
        else
        {
            interactBtn.GetComponent<Image>().color = Color.black;
            txtInteractable.color = Color.black;
            countBtn = 0;
        }
    }
    
    public void tutBtn()
    {
        isClose = true;
        tutLevel += 1;
        if(tutLevel > 4)
        {
            GameObject.FindGameObjectWithTag("GameManager").GetComponent<Transition>().loadTransition("Main Menu");
        }
            sfxMenu();
    }

    IEnumerator moveTut()
    {
        isContinue = true;
        yield return new WaitForSeconds(3f);
        isClose = false;
        
    }

    void afterSkeli()
    {
        if (isContinue1 == false)
        {
            if (skeleton == null)
            {
                if (PlayerPrefs.GetInt("tut") == 0)
                {
                    PlayerPrefs.SetInt("skillPoints", 5);
                    PlayerPrefs.SetInt("tut", 29479182);
                }
                isContinue1 = true;
                isClose = false;
            }
        }
    }
    void sfxMenu()
    {
        this.GetComponent<menuSFX>().menuSound();
    }
}
