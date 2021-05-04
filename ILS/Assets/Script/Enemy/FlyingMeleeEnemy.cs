using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FlyingMeleeEnemy : MonoBehaviour
{
    GameObject player;
    public Animator anim;
    public float range;
    public float alertRange;

    public float damage = 5f;
    private float attackTimer = 1f;
    private float timer;

    public AudioSource sfx;

    private bool isAlert = false;
    private bool isAttacking = false;
    float Dist;
    bool isDmg = false;
    NavMeshAgent agent;
    bool isSFX = false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }


    void Update()
    {
        sfx.volume = (PlayerPrefs.GetFloat("sfxValue") / 100);
        Dist = Vector3.Distance(player.transform.position, this.transform.position);
        float alertDis = Dist;

        if (alertDis <= alertRange)
        {
            isAlert = true;
        }

        if (isAlert == true)
        {
            //attack
            if (Dist <= range)
            {
                timer += Time.deltaTime;
                if (timer >= attackTimer)
                {
                    if (isSFX == false)
                    {
                        StartCoroutine("attackDelay");
                        timer = 0;
                    }
                }
            }
            //move
            else if (Dist > range && isAttacking == false)
            {
                agent.SetDestination(player.transform.position);
            }
        }

        //rotate
        if (transform.position.x > player.transform.position.x)
        {
            transform.localScale = new Vector3(1.5f, 1.5f, 1);
        }
        else
        {
            transform.localScale = new Vector3(-1.5f, 1.5f, 1);
        }

    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, range);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(this.transform.position, alertRange);
    }

    IEnumerator attackDelay()
    {

        isSFX = true;
        isAttacking = true;
        yield return new WaitForSeconds(1f);

        sfx.Play();
        anim.Play("Flying Enemy Attack");
        yield return new WaitForSeconds(1.3f);
        isAttacking = false;
        isSFX = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().playerTakeDamage(2);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (isAttacking == true)
            {
                if (isDmg == false)
                {
                    isDmg = true;
                    collision.gameObject.GetComponent<Player>().playerTakeDamage(damage);
                    StartCoroutine("dmgCD");
                }
            }
        }
    }

    IEnumerator dmgCD()
    {
        yield return new WaitForSeconds(0.7f);
        isDmg = false;
    }

}
