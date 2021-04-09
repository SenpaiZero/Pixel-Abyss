using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserEnemy : MonoBehaviour
{
    public float damage = 2f;

    bool isShooting = false;


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (isShooting == false)
            {
                StartCoroutine(cooldown(collision));
            }
        }
    }

    IEnumerator cooldown(Collider2D collision)
    {
        isShooting = true;
        collision.gameObject.GetComponent<Player>().playerTakeDamage(damage);
        yield return new WaitForSeconds(0.5f);
        isShooting = false;
    }
}
