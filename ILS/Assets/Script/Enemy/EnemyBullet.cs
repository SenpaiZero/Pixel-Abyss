using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float damage = 10f;
    public bool isDelay = false;

    Rigidbody2D rb;

    private void Start()
    {
        if(isDelay == true)
        {
            rb = GetComponent<Rigidbody2D>();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().playerTakeDamage(damage);
        }

        if (isDelay == false)
        {
            Destroy(gameObject);
        }
        else
        {
            if (collision.gameObject.tag != "Player")
            {
                StartCoroutine(removeRB());
                Destroy(gameObject, 5f);
            }
        }
    }

    IEnumerator removeRB()
    {
        yield return new WaitForSeconds(0.05f);
        rb.simulated = false;
    }

}
