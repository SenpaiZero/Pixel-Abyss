using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BoarEnemy : MonoBehaviour
{
    GameObject player;
    public Animator anim;
    public float range;
    public float alertRange;

    public float damage = 5f;
    private float attackTimer =  1f;
    private float timer;

    private bool isAlert = false;
    NavMeshAgent agent;
    private Rigidbody2D rb;
    private bool isAttacking = false;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    private void Update()
    {
        float Dist = Vector3.Distance(player.transform.position, this.transform.position);
        float alertDis = Dist;

        if(alertDis <= alertRange)
        {
            isAlert = true;
        }

        if (isAlert == true) {
            //attack
            if (Dist <= range)
            {
                timer+= Time.deltaTime;
                if (timer >= attackTimer)
                {
                    StartCoroutine("attackDelay");
                    timer = 0;
                }
            }
            //move
            else if (Dist > range && isAttacking == false)
            {
                agent.SetDestination(player.transform.position);
            } 
        }

        //rotate
        if(transform.position.x > player.transform.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    void attack()
    {
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
        isAttacking = true;
        yield return new WaitForSeconds(1f);

        anim.Play("attackBoar");
        player.GetComponent<Player>().playerTakeDamage(damage);
        Debug.Log("attacking melee");

        yield return new WaitForSeconds(0.5f);
        isAttacking = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().playerTakeDamage(2);
        }
    }
}
