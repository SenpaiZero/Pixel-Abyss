﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    private int rand;
    public AudioSource sfx;
    public SpriteRenderer sp;
    public CircleCollider2D cr;
    private void Start()
    {
        rand = Random.Range(1, 5);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {

            sfx.Play();
            sp.enabled = false;
            cr.enabled = false;
            collision.gameObject.GetComponent<Player>().coinPickup(rand);
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + rand);
            PlayerPrefs.Save();

            Destroy(gameObject, 3f);
        }
    }
}
