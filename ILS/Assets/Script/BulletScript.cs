using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private float wandDamage;
    private AudioSource hitSFX;

    [SerializeField] private GameObject explosionPrefab;
    private void Awake()
    {
        wandDamage = PlayerPrefs.GetFloat("wandDamage");
        hitSFX = GameObject.FindGameObjectWithTag("PlayerParent").GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        GameObject clone = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        GameObject cam = GameObject.FindGameObjectWithTag("MainCamera");
        cam.GetComponent<Animator>().Play("CamShake");
        hitSFX.Play();

        if (collision.gameObject.tag == "Enemy")
        {
            collision.GetComponent<Enemy>().takeDamage(wandDamage);
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
