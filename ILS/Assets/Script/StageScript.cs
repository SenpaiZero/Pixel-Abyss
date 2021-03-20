using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageScript : MonoBehaviour
{
    public int stageNumber;
    private GameObject trans;

    private void Start()
    {
        trans = GameObject.FindGameObjectWithTag("GameManager");
    }

    public void stageBtn()
    {
        trans.GetComponent<Transition>().loadTransition("Stage " + stageNumber);
    }

}
