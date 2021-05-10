using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class skeletonEnemy : MonoBehaviour
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
    bool isWithin = true;
    float Dist;
    NavMeshAgent agent;
    void Start()
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
                isWithin = true;
                timer += Time.deltaTime;
                if (timer >= attackTimer)
                {
                    StartCoroutine("attackDelay");
                    timer = 0;
                }
            }
            //move
            else if (Dist > range && isAttacking == false)
            {
                isWithin = false;
                agent.SetDestination(player.transform.position);
            }
        }

        if(isWithin == false)
        {
            anim.Play("skeliLeftWalk");
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
        isAttacking = true;
        print(player);
        yield return new WaitForSeconds(1f);

        anim.Play("skeliLeftAttack");
        sfx.Play();
        if (Dist <= range)
        {
            FindObjectOfType<Player>().playerTakeDamage(damage);
        }
        Debug.Log("skeliLeftAttack");

        yield return new WaitForSeconds(1f);
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
