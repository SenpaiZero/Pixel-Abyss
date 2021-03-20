﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
    public Animator transitionAnim;
    private float transitionTime = 2f;

    private void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 30;
    }

    void Update()
    {
        //Debug
        if(Input.GetKeyDown(KeyCode.Q))
        {
            loadTransition("Base");
        }
    }

    public void loadTransition(string sceneName_)
    {
        StartCoroutine(loadLevel(sceneName_));
    }

    IEnumerator loadLevel(string sceneName)
    {
        transitionAnim.SetTrigger("Start");
        Enemy.enemyList.Clear();
        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(sceneName);

    }
}
