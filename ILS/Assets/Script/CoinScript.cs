using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    private int rand;
    private void Start()
    {
        rand = Random.Range(1, 5);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().coinPickup(rand);
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + rand);
            PlayerPrefs.Save();
            Destroy(gameObject);
        }
    }
}
