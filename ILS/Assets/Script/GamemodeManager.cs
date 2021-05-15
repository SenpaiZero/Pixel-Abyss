using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GamemodeManager : MonoBehaviour
{
    public GameObject gamemodeObj;
    public TextMeshProUGUI highestWaveText;

    private void Update()
    {
        highestWaveText.text = "HIGHSCORE: " + PlayerPrefs.GetInt("highestWave");
    }

    public void openWave()
    {
        sfxMenu();
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<Transition>().loadTransition("Wave");
    }

    public void closeGamemode()
    {
        sfxMenu();
        gamemodeObj.SetActive(false);
    }

    void sfxMenu()
    {
        GameObject.FindGameObjectWithTag("MenuSfx").GetComponent<menuSFX>().menuSound();
    }
}
