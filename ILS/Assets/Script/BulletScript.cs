using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private float wandDamage;
    private AudioSource hitSFX;
    float rand;

    [SerializeField] private GameObject explosionPrefab;
    private void Awake()
    {
        wandDamage = PlayerPrefs.GetFloat("wandDamage");
        hitSFX = GameObject.FindGameObjectWithTag("PlayerParent").GetComponent<AudioSource>();
    }

    private void Start()
    {
        rand = Random.Range(1, 101);
        print(rand);
    }
    private void Update()
    {
        hitSFX.volume = (PlayerPrefs.GetFloat("sfxValue") / 100);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        GameObject clone = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        if (PlayerPrefs.GetInt("isShake") == 0)
        {
            GameObject cam = GameObject.FindGameObjectWithTag("MainCamera");
            cam.GetComponent<Animator>().Play("CamShake");
        }
        hitSFX.Play();

        if (collision.gameObject.tag == "Enemy")
        {
            if (rand > PlayerPrefs.GetFloat("critChance"))
            {
                collision.GetComponent<Enemy>().takeDamage(wandDamage, false);
            }
            else
            {
                collision.GetComponent<Enemy>().takeDamage(wandDamage * 2, true);
            }
        }

        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "GrassWall")
        {
            Destroy(gameObject, 20);
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
