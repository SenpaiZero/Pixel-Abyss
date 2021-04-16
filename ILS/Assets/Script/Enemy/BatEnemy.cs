using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BatEnemy : MonoBehaviour
{
    GameObject player;
    public GameObject bullet;
    public Transform bulletPos;
    public Transform bulletPos2;
    public Transform bulletPos3;
    public Transform bulletPos4;
    public Transform bulletPos5;
    public Transform bulletPos6;
    public Transform bulletPos7;
    public Transform bulletPos8;
    public float range;
    public float alertRange;
    public float bulletSpeed;


    public float damage = 5f;
    private float attackTimer = 6f;
    private float timer;

    public AudioSource sfx;

    private bool isAlert = false;
    NavMeshAgent agent;
    public SpriteRenderer batRen;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    void Update()
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
                    getRotation();
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
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
    IEnumerator delayAttack()
    {
        agent.enabled = false;
        sfx.Play();
        batRen.color = Color.Lerp(Color.white, Color.red, 10);
        yield return new WaitForSeconds(1f);
        attack();
        yield return new WaitForSeconds(0.2f);
        attack();
        yield return new WaitForSeconds(0.2f);
        attack();
        yield return new WaitForSeconds(0.2f);
        attack();
        yield return new WaitForSeconds(1f);
        agent.enabled = true;

        batRen.color = Color.Lerp(Color.red, Color.white, 1);
    }
    void attack()
    {
        //1
        GameObject clone = Instantiate(bullet, bulletPos.position, bulletPos.rotation);
        Rigidbody2D crb = clone.GetComponent<Rigidbody2D>();
        crb.AddForce(bulletPos.up * bulletSpeed, ForceMode2D.Impulse);
        crb.velocity = Vector2.ClampMagnitude(crb.velocity, bulletSpeed);

        //2
        GameObject clone2 = Instantiate(bullet, bulletPos2.position, bulletPos2.rotation);
        Rigidbody2D crb2 = clone2.GetComponent<Rigidbody2D>();
        crb2.AddForce(bulletPos2.up * bulletSpeed, ForceMode2D.Impulse);
        crb2.velocity = Vector2.ClampMagnitude(crb2.velocity, bulletSpeed);
        //3
        GameObject clone3 = Instantiate(bullet, bulletPos3.position, bulletPos3.rotation);
        Rigidbody2D crb3 = clone3.GetComponent<Rigidbody2D>();
        crb3.AddForce(bulletPos3.up * bulletSpeed, ForceMode2D.Impulse);
        crb3.velocity = Vector2.ClampMagnitude(crb3.velocity, bulletSpeed);
        //4
        GameObject clone4 = Instantiate(bullet, bulletPos4.position, bulletPos4.rotation);
        Rigidbody2D crb4 = clone4.GetComponent<Rigidbody2D>();
        crb4.AddForce(bulletPos4.up * bulletSpeed, ForceMode2D.Impulse);
        crb4.velocity = Vector2.ClampMagnitude(crb4.velocity, bulletSpeed);
        //5
        GameObject clone5 = Instantiate(bullet, bulletPos5.position, bulletPos5.rotation);
        Rigidbody2D crb5 = clone5.GetComponent<Rigidbody2D>();
        crb5.AddForce(bulletPos5.up * bulletSpeed, ForceMode2D.Impulse);
        crb5.velocity = Vector2.ClampMagnitude(crb5.velocity, bulletSpeed);
        //6
        GameObject clone6 = Instantiate(bullet, bulletPos6.position, bulletPos6.rotation);
        Rigidbody2D crb6 = clone6.GetComponent<Rigidbody2D>();
        crb6.AddForce(bulletPos6.up * bulletSpeed, ForceMode2D.Impulse);
        crb6.velocity = Vector2.ClampMagnitude(crb6.velocity, bulletSpeed);
        //7
        GameObject clone7 = Instantiate(bullet, bulletPos7.position, bulletPos7.rotation);
        Rigidbody2D crb7 = clone7.GetComponent<Rigidbody2D>();
        crb7.AddForce(bulletPos7.up * bulletSpeed, ForceMode2D.Impulse);
        crb7.velocity = Vector2.ClampMagnitude(crb7.velocity, bulletSpeed);
        //8
        GameObject clone8 = Instantiate(bullet, bulletPos8.position, bulletPos8.rotation);
        Rigidbody2D crb8 = clone8.GetComponent<Rigidbody2D>();
        crb8.AddForce(bulletPos8.up * bulletSpeed, ForceMode2D.Impulse);
        crb8.velocity = Vector2.ClampMagnitude(crb8.velocity, bulletSpeed);

        Destroy(clone, 10f);
        Destroy(clone2, 10f);
        Destroy(clone3, 10f);
        Destroy(clone4, 10f);
        Destroy(clone5, 10f);
        Destroy(clone6, 10f);
        Destroy(clone7, 10f);
        Destroy(clone8, 10f);


        Debug.Log("bat attack");
    }

    void getRotation()
    {
        Vector3 dir = player.transform.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;

        bulletPos.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        bulletPos2.rotation = Quaternion.AngleAxis(angle - 180, Vector3.forward);
        bulletPos3.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);
        bulletPos4.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        bulletPos5.rotation = Quaternion.AngleAxis(angle - 145, Vector3.forward);
        bulletPos6.rotation = Quaternion.AngleAxis(angle + 145, Vector3.forward);
        bulletPos7.rotation = Quaternion.AngleAxis(angle - 45, Vector3.forward);
        bulletPos8.rotation = Quaternion.AngleAxis(angle + 45, Vector3.forward);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, range);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(this.transform.position, alertRange);
    }
}
