using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillDamage : MonoBehaviour
{
    private float skillTick = 0.5f;
    private float timer = 0;
    private float skillDmg;
    public float range;
    public CapsuleCollider2D capsulCol;

    public LayerMask enemyLayer;

    private void Start()
    {
        timer = skillTick;
    }

    private void Update()
    {
         skillDmg = PlayerPrefs.GetFloat("wandDamage") / 3;

        timer+=Time.deltaTime;
        if(timer > skillTick)
        {
            timer = skillTick;
        }


        Collider2D[] enemyInRange = Physics2D.OverlapCircleAll(transform.position, range, enemyLayer);
        if (capsulCol.isActiveAndEnabled == true)
        {
            if (timer >= skillTick)
            {
                for (int i = 0; i < enemyInRange.Length; i++)
                {
                    enemyInRange[i].GetComponent<Enemy>().takeDamage(skillDmg);
                    Debug.Log("Enemy Skill Damaged Taken");
                    timer =0;
                }
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }



}
