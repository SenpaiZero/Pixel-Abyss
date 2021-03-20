using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonTrap : MonoBehaviour
{
    private float poisonDamage = 3f;
    private float damageSpeed = 0.3f;

    private float timer = 0;
    private bool isPoison = false;
    private GameObject player;

    private void Start()
    {
        timer = damageSpeed;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        timer+=Time.deltaTime;
        if(timer > damageSpeed)
        {
            timer = damageSpeed;
        }


        if(isPoison == true)
        {
            Debug.Log("TickTick");
            if (timer >= damageSpeed)
            {
                Debug.Log("Poison Damage: " + poisonDamage);
                player.GetComponent<Player>().playerTakeDamage(poisonDamage);
                timer = 0;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            isPoison = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            isPoison = false;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isPoison = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isPoison = false;
        }
    }
}
