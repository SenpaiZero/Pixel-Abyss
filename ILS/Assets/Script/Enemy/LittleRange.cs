using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LittleRange : MonoBehaviour
{
    GameObject player;
    public GameObject bullet;
    public Transform bulletPos;
    public float range;
    public float alertRange;
    public float bulletSpeed;


    public float damage = 5f;
    private float attackTimer = 2f;
    private float timer;

    public AudioSource sfx;

    private bool isAlert = false;
    NavMeshAgent agent;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }
    private void Update()
    {
        float Dist = Vector3.Distance(player.transform.position, this.transform.position);
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

                    Vector3 dir = player.transform.position - transform.position;
                    float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
                    bulletPos.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                    sfx.Play();
                    attack();
                    agent.SetDestination(-player.transform.position);
                    timer = 0;
                }
            }
            //move
            else if (Dist > range)
            {
                agent.SetDestination(player.transform.position);
            } 
        }

        //rotate
        if (transform.position.x > player.transform.position.x)
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
        timer = 0;
        GameObject clone = Instantiate(bullet, bulletPos.position, bulletPos.rotation);
        Rigidbody2D crb = clone.GetComponent<Rigidbody2D>();
        crb.AddForce(bulletPos.up * bulletSpeed, ForceMode2D.Impulse);
        crb.velocity = Vector2.ClampMagnitude(crb.velocity, bulletSpeed);


        Debug.Log("LittleRangeAttack");
    }


    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, range);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(this.transform.position, alertRange);
    }

}
