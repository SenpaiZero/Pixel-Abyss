using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ScorpionEnemy : MonoBehaviour
{
    GameObject player;
    public GameObject bullet;
    public Transform bulletPos;
    public Transform bulletPos2;
    public Transform bulletPos3;
    public float range;
    public float alertRange;
    public float bulletSpeed;


    public float damage = 5f;
    private float attackTimer = 3f;
    private float timer;

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
        timer += Time.deltaTime;

        if (alertDis <= alertRange)
        {
            isAlert = true;
        }

        if (isAlert == true)
        {
            //attack
            if (Dist <= range)
            {
                if (timer >= attackTimer)
                {

                    Vector3 dir = player.transform.position - transform.position;
                    float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
                    bulletPos.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                    bulletPos2.rotation = Quaternion.AngleAxis(angle - 35, Vector3.forward);
                    bulletPos3.rotation = Quaternion.AngleAxis(angle + 35, Vector3.forward);
                    StartCoroutine("delayAttack");

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
        if (transform.position.x < player.transform.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    IEnumerator delayAttack()
    {
        attack();
        yield return new WaitForSeconds(0.2f);
        attack();
        yield return new WaitForSeconds(0.2f);
        attack();
    }
    void attack()
    {
        //bullet 1
        GameObject clone = Instantiate(bullet, bulletPos.position, bulletPos.rotation);
        Rigidbody2D crb = clone.GetComponent<Rigidbody2D>();
        crb.AddForce(bulletPos.up * bulletSpeed, ForceMode2D.Impulse);
        crb.velocity = Vector2.ClampMagnitude(crb.velocity, bulletSpeed);

        //bullet 2
        GameObject clone2 = Instantiate(bullet, bulletPos2.position, bulletPos2.rotation);
        Rigidbody2D crb2 = clone2.GetComponent<Rigidbody2D>();
        crb2.AddForce(bulletPos2.up * bulletSpeed, ForceMode2D.Impulse);
        crb2.velocity = Vector2.ClampMagnitude(crb2.velocity, bulletSpeed);

        //bullet 3
        GameObject clone3 = Instantiate(bullet, bulletPos3.position, bulletPos3.rotation);
        Rigidbody2D crb3 = clone3.GetComponent<Rigidbody2D>();
        crb3.AddForce(bulletPos3.up * bulletSpeed, ForceMode2D.Impulse);
        crb3.velocity = Vector2.ClampMagnitude(crb3.velocity, bulletSpeed);


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
