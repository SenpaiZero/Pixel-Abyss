using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{
    public GameObject pauseObj;
    public GameObject settingObj;
    public GameObject firstCanvas;
    GameObject trans;

    private void Start()
    {
        trans = GameObject.FindGameObjectWithTag("GameManager");
    }

    public void openPause()
    {
        firstCanvas.SetActive(false);
        pauseObj.SetActive(true);
        trans.GetComponent<AudioSource>().pitch = 0.9f;
        Time.timeScale = 0;
    }

    public void resume()
    {
        firstCanvas.SetActive(true);
        pauseObj.SetActive(false);
        trans.GetComponent<AudioSource>().pitch = 1f;
        Time.timeScale = 1;
    }

    public void exitStage()
    {
        firstCanvas.SetActive(true);
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
        settingObj.SetActive(true);
    }

    public void closeSetting()
    {
        settingObj.SetActive(false);
    }
}
