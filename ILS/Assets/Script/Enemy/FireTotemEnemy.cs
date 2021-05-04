using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTotemEnemy : MonoBehaviour
{
    GameObject player;
    public GameObject bullet;
    public float range;
    public float bulletSpeed;
    public float damage = 5f;
    private float attackTimer = 6f;
    private float timer;
    public Transform[] bulletPos;

    public AudioSource sfx;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        sfx.volume = (PlayerPrefs.GetFloat("sfxValue") / 100);
        float Dist = Vector3.Distance(player.transform.position, this.transform.position);
        timer += Time.deltaTime;
        //attack
        if (Dist <= range)
        {
            if (timer >= attackTimer)
            {
                getRotate();
                StartCoroutine("delayAttack");

                timer = 0;
            }
        }
        //rotate
        if (transform.position.x < player.transform.position.x)
        {
            transform.localScale = new Vector3(3, 3, 1);
        }
        else
        {
            transform.localScale = new Vector3(-3, 3, 1);
        }
    }

    void getRotate()
    {
        Vector3 dir = player.transform.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;

        bulletPos[0].rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        bulletPos[1].rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        bulletPos[2].rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        bulletPos[3].rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        bulletPos[4].rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        bulletPos[5].rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        bulletPos[6].rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        bulletPos[7].rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        bulletPos[8].rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        bulletPos[9].rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        bulletPos[10].rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        bulletPos[11].rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    IEnumerator delayAttack()
    {
        GameObject clone1 = Instantiate(bullet, bulletPos[0].position, bulletPos[0].rotation);
        GameObject clone2 = Instantiate(bullet, bulletPos[1].position, bulletPos[1].rotation);
        GameObject clone3 = Instantiate(bullet, bulletPos[2].position, bulletPos[2].rotation);
        GameObject clone4 = Instantiate(bullet, bulletPos[3].position, bulletPos[3].rotation);
        GameObject clone5 = Instantiate(bullet, bulletPos[4].position, bulletPos[4].rotation);
        GameObject clone6 = Instantiate(bullet, bulletPos[5].position, bulletPos[5].rotation);
        GameObject clone7 = Instantiate(bullet, bulletPos[6].position, bulletPos[6].rotation);
        GameObject clone8 = Instantiate(bullet, bulletPos[7].position, bulletPos[7].rotation);
        GameObject clone9 = Instantiate(bullet, bulletPos[8].position, bulletPos[8].rotation);
        GameObject clone10 = Instantiate(bullet, bulletPos[9].position, bulletPos[9].rotation);
        GameObject clone11 = Instantiate(bullet, bulletPos[10].position, bulletPos[10].rotation);
        GameObject clone12 = Instantiate(bullet, bulletPos[11].position, bulletPos[11].rotation);
        sfx.Play();

        yield return new WaitForSeconds(2.1f);

        //1
        if (clone1 != null)
        {
            Rigidbody2D crb1 = clone1.GetComponent<Rigidbody2D>();
            crb1.AddForce(bulletPos[0].up * bulletSpeed, ForceMode2D.Impulse);
            crb1.velocity = Vector2.ClampMagnitude(crb1.velocity, bulletSpeed);
        }
        //2
        if (clone2 != null)
        {
            Rigidbody2D crb2 = clone2.GetComponent<Rigidbody2D>();
            crb2.AddForce(bulletPos[1].up * bulletSpeed, ForceMode2D.Impulse);
            crb2.velocity = Vector2.ClampMagnitude(crb2.velocity, bulletSpeed);
        }
        //3
        if (clone3 != null)
        {
            Rigidbody2D crb3 = clone3.GetComponent<Rigidbody2D>();
            crb3.AddForce(bulletPos[2].up * bulletSpeed, ForceMode2D.Impulse);
            crb3.velocity = Vector2.ClampMagnitude(crb3.velocity, bulletSpeed);
        }
        //4
        if (clone4 != null) {
            Rigidbody2D crb4 = clone4.GetComponent<Rigidbody2D>();
            crb4.AddForce(bulletPos[3].up * bulletSpeed, ForceMode2D.Impulse);
            crb4.velocity = Vector2.ClampMagnitude(crb4.velocity, bulletSpeed); 
        }
        //5
        if (clone5 != null) {
            Rigidbody2D crb5 = clone5.GetComponent<Rigidbody2D>();
            crb5.AddForce(bulletPos[4].up * bulletSpeed, ForceMode2D.Impulse);
            crb5.velocity = Vector2.ClampMagnitude(crb5.velocity, bulletSpeed);
        }
        //6
        if (clone6 != null) {
            Rigidbody2D crb6 = clone6.GetComponent<Rigidbody2D>();
            crb6.AddForce(bulletPos[5].up * bulletSpeed, ForceMode2D.Impulse);
            crb6.velocity = Vector2.ClampMagnitude(crb6.velocity, bulletSpeed);
        }
        //7
        if (clone7 != null) {
            Rigidbody2D crb7 = clone7.GetComponent<Rigidbody2D>();
            crb7.AddForce(bulletPos[6].up * bulletSpeed, ForceMode2D.Impulse);
            crb7.velocity = Vector2.ClampMagnitude(crb7.velocity, bulletSpeed);
        }
        //8
        if (clone8 != null) {
            Rigidbody2D crb8 = clone8.GetComponent<Rigidbody2D>();
            crb8.AddForce(bulletPos[7].up * bulletSpeed, ForceMode2D.Impulse);
            crb8.velocity = Vector2.ClampMagnitude(crb8.velocity, bulletSpeed);
        }
        //9
        if (clone9 != null) {
            Rigidbody2D crb9 = clone9.GetComponent<Rigidbody2D>();
            crb9.AddForce(bulletPos[8].up * bulletSpeed, ForceMode2D.Impulse);
            crb9.velocity = Vector2.ClampMagnitude(crb9.velocity, bulletSpeed);
        }
        //10
        if (clone10 != null) {
            Rigidbody2D crb10 = clone10.GetComponent<Rigidbody2D>();
            crb10.AddForce(bulletPos[9].up * bulletSpeed, ForceMode2D.Impulse);
            crb10.velocity = Vector2.ClampMagnitude(crb10.velocity, bulletSpeed);
        }
        //11
        if (clone11 != null)
        {
            Rigidbody2D crb11 = clone11.GetComponent<Rigidbody2D>();
            crb11.AddForce(bulletPos[10].up * bulletSpeed, ForceMode2D.Impulse);
            crb11.velocity = Vector2.ClampMagnitude(crb11.velocity, bulletSpeed);
        }
        //12
        if (clone12 != null)
        {
            Rigidbody2D crb12 = clone12.GetComponent<Rigidbody2D>();
            crb12.AddForce(bulletPos[11].up * bulletSpeed, ForceMode2D.Impulse);
            crb12.velocity = Vector2.ClampMagnitude(crb12.velocity, bulletSpeed);
        }
    }


    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, range);
    }
}
