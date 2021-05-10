using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class waveManager : MonoBehaviour
{ 
    public Transform[] spawnPoint;
    public GameObject[] enemies;
    public Animator waveAnim;
    public TextMeshProUGUI waveTxt;

    private int waveCount = 0;
    private int spawnCount = 0;

    private int enemyCount;

    //IENUMERTOR CONTROLLER
    private bool isCount = false;
    private bool isNextWave = false;


    private void LateUpdate()
    {
        if (isCount == false){StartCoroutine(delayEnemyCount());}
        if(enemyCount <= 0){
            waveTxt.text = "WAVE " + waveCount + "\n<size=50><color=green> ENEMIES: " + (4*spawnCount) + "</size ></color >";
            if(isNextWave == false)
            StartCoroutine("nextWave");
        }
        else
        {
            StopCoroutine("nextWave");
        }
    }

    IEnumerator nextWave()
    {
        isNextWave = true;
        waveAnim.Play("wave on");
        waveCount++;
        spawnCount++;
        print("wave:" + waveCount + "-- SpawnCount: " + spawnCount);
        yield return new WaitForSeconds(2f);
        //wait 2s before spawning new mobs
        spawnMobs();
        isNextWave = false;
    }

    private void spawnMobs()
    {
        int randomEnemy;
        int randomEnemy1;
        int randomEnemy2;
        int randomEnemy3;
        for (int i = 0; i < spawnCount; i++)
        {
            randomEnemy = Random.Range(0, enemies.Length);
            randomEnemy1 = Random.Range(0, enemies.Length);
            randomEnemy2 = Random.Range(0, enemies.Length);
            randomEnemy3 = Random.Range(0, enemies.Length);
            Instantiate(enemies[randomEnemy], spawnPoint[0].position, Quaternion.identity);
            Instantiate(enemies[randomEnemy1], spawnPoint[1].position, Quaternion.identity);
            Instantiate(enemies[randomEnemy2], spawnPoint[2].position, Quaternion.identity);
            Instantiate(enemies[randomEnemy3], spawnPoint[3].position, Quaternion.identity);
        }
    }
    IEnumerator delayEnemyCount()
    {
        isCount = true;
        enemyCount = Enemy.enemyList.Count;
        yield return new WaitForSeconds(1f);
        isCount = false;
    }
}
