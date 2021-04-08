using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss5Enemy : MonoBehaviour
{
    GameObject player;
    public Animator bodyAnim;

    [Space]
    [Header("Shoot rotating bullet")]
    public Transform bulletRot;
    public Transform[] bulletPos; //0-3
    public GameObject bullet;

    [Space]
    public int bulletCount = 10;
    public float bulletSpeed;
    public float fireRate;
    public float bulletRotSpeed;
    bool isRotate = false;
    bool isRotateAttack = false;

    //[Header("Hand Attack")]

    [Header("follow spike attack")]
    public GameObject prefabSpike;
    public Transform[] spikePos;
    public float spikeSpeed;
    bool isSpikeAttack = false;


    //etx private
    Vector3 dir;
    float angle;
    Quaternion spikeRot;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if(isRotate == true)
        {
            bulletRot.Rotate(new Vector3(0, 0, bulletRotSpeed * Time.deltaTime));
        }

        if (isRotateAttack == false)
        {
            //StartCoroutine("rotateAttack");
        }

        if(isSpikeAttack == false)
        {
            StartCoroutine(spikeAttack());
        }
    }

    IEnumerator rotateAttack()
    {
        isRotateAttack = true;
        isRotate = true;
        int i = 0;
        while(i < bulletCount) { 
            rotateShooting();
            i++;
            print(i);
            yield return new WaitForSeconds(fireRate);
        }

        //isRotateAttack = false;
        isRotate = false;
    }

    private void rotateShooting()
    {
        //1
        GameObject clone = Instantiate(bullet, bulletPos[0].position, bulletPos[0].rotation);
        Rigidbody2D crb = clone.GetComponent<Rigidbody2D>();
        crb.AddForce(bulletPos[0].up * bulletSpeed, ForceMode2D.Impulse);
        crb.velocity = Vector2.ClampMagnitude(crb.velocity, bulletSpeed);
        //2
        GameObject clone2 = Instantiate(bullet, bulletPos[1].position, bulletPos[1].rotation);
        Rigidbody2D crb2 = clone2.GetComponent<Rigidbody2D>();
        crb2.AddForce(bulletPos[1].up * bulletSpeed, ForceMode2D.Impulse);
        crb2.velocity = Vector2.ClampMagnitude(crb2.velocity, bulletSpeed);
        //3
        GameObject clone3 = Instantiate(bullet, bulletPos[2].position, bulletPos[2].rotation);
        Rigidbody2D crb3 = clone3.GetComponent<Rigidbody2D>();
        crb3.AddForce(bulletPos[2].up * bulletSpeed, ForceMode2D.Impulse);
        crb3.velocity = Vector2.ClampMagnitude(crb3.velocity, bulletSpeed);
        //4
        GameObject clone4 = Instantiate(bullet, bulletPos[3].position, bulletPos[3].rotation);
        Rigidbody2D crb4 = clone4.GetComponent<Rigidbody2D>();
        crb4.AddForce(bulletPos[3].up * bulletSpeed, ForceMode2D.Impulse);
        crb4.velocity = Vector2.ClampMagnitude(crb4.velocity, bulletSpeed);
    }

    IEnumerator spikeAttack()
    {
        isSpikeAttack = true;
        bodyAnim.Play("SpikeAttackBody");
        GameObject clone = Instantiate(prefabSpike, spikePos[0].position, Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        GameObject clone1 = Instantiate(prefabSpike, spikePos[1].position, Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        GameObject clone2 = Instantiate(prefabSpike, spikePos[2].position, Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        GameObject clone3 = Instantiate(prefabSpike, spikePos[3].position, Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        GameObject clone4 = Instantiate(prefabSpike, spikePos[4].position, Quaternion.identity);


        yield return new WaitForSeconds(2f);
        spikeRot_(0);
        //attack 1
        spikePos[0].rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        Rigidbody2D crb = clone.GetComponent<Rigidbody2D>();
        crb.AddForce(spikePos[0].up * bulletSpeed, ForceMode2D.Impulse);
        crb.velocity = Vector2.ClampMagnitude(crb.velocity, bulletSpeed);
        clone.GetComponent<Transform>().rotation = spikeRot;

        yield return new WaitForSeconds(0.7f);
        spikeRot_(1);
        //attack 2
        spikePos[1].rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        Rigidbody2D crb1 = clone1.GetComponent<Rigidbody2D>();
        crb1.AddForce(spikePos[1].up * bulletSpeed, ForceMode2D.Impulse);
        crb1.velocity = Vector2.ClampMagnitude(crb1.velocity, bulletSpeed);
        clone1.GetComponent<Transform>().rotation = spikeRot;

        yield return new WaitForSeconds(0.7f);
        spikeRot_(2);
        //attack 3
        spikePos[2].rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        Rigidbody2D crb2 = clone2.GetComponent<Rigidbody2D>();
        crb2.AddForce(spikePos[2].up * bulletSpeed, ForceMode2D.Impulse);
        crb2.velocity = Vector2.ClampMagnitude(crb2.velocity, bulletSpeed);
        clone2.GetComponent<Transform>().rotation = spikeRot;

        yield return new WaitForSeconds(0.7f);
        spikeRot_(3);
        //attack 4
        spikePos[3].rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        Rigidbody2D crb3 = clone3.GetComponent<Rigidbody2D>();
        crb3.AddForce(spikePos[3].up * bulletSpeed, ForceMode2D.Impulse);
        crb3.velocity = Vector2.ClampMagnitude(crb3.velocity, bulletSpeed);
        clone3.GetComponent<Transform>().rotation = spikeRot;

        yield return new WaitForSeconds(0.7f);
        spikeRot_(4);
        //attack 5
        spikePos[4].rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        Rigidbody2D crb4 = clone4.GetComponent<Rigidbody2D>();
        crb4.AddForce(spikePos[4].up * bulletSpeed, ForceMode2D.Impulse);
        crb4.velocity = Vector2.ClampMagnitude(crb4.velocity, bulletSpeed);
        clone4.GetComponent<Transform>().rotation = spikeRot;

        yield return new WaitForSeconds(0.5f);
        bodyAnim.Play("bossIdle");
        isSpikeAttack = false;

    }

    private void spikeRot_(int i)
    {
        dir = player.transform.position - spikePos[i].transform.position;
        angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
        spikeRot = Quaternion.AngleAxis(angle - 180, Vector3.forward);
    }
}
