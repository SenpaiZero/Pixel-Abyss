using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DeadCanvasScript : MonoBehaviour
{
    public TextMeshProUGUI lostTxt;
    GameObject player;
    int lostCoins;
    float lostExp;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        lostCoins = player.GetComponent<Player>().lostCoins;
        lostExp = player.GetComponent<Player>().lostExp;

        lostTxt.text = "YOU LOST \n" + lostCoins + " Coins \n" + lostExp + " Experience";
    }

    public void _restartBtn()
    {
        string sceneName;
        sceneName = SceneManager.GetActiveScene().name;

        SceneManager.LoadScene(sceneName);
    }

    public void _ExitBtn()
    {
        SceneManager.LoadScene("Base");
    }
}
