using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{
    public GameObject pauseObj;
    public GameObject settingObj;
    public GameObject firstCanvas;
    public static bool isPause = false;

    GameObject sfx;
    GameObject trans;

    private void Start()
    {
        trans = GameObject.FindGameObjectWithTag("GameManager");
        sfx = GameObject.FindGameObjectWithTag("MenuSfx");
    }

    public void openPause()
    {
        sfx.GetComponent<menuSFX>().menuSound();
        firstCanvas.SetActive(false);
        pauseObj.SetActive(true);
        Time.timeScale = 0;
    }

    public void resume()
    {
        sfx.GetComponent<menuSFX>().menuSound();
        firstCanvas.SetActive(true);
        pauseObj.SetActive(false);
        Time.timeScale = 1;
    }

    public void exitStage()
    {
        firstCanvas.SetActive(true);
        sfx.GetComponent<menuSFX>().menuSound();
        isPause = true;
        if (SceneManager.GetActiveScene().name == "Base")
        {
            resume();
            trans.GetComponent<Transition>().loadTransition("Main Menu");
        }
        else
        {
            resume();
            trans.GetComponent<Transition>().loadTransition("Base");
        }
    }

    public void openSetting()
    {
        sfx.GetComponent<menuSFX>().menuSound();
        settingObj.SetActive(true);
    }

    public void closeSetting()
    {
        sfx.GetComponent<menuSFX>().menuSound();
        settingObj.SetActive(false);
    }

    private void OnDestroy()
    {
        isPause = false;
    }
}
