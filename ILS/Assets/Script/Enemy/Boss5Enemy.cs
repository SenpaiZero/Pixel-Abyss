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
    public AudioSource rotSFX;

    [Space]
    public int bulletCount = 10;
    public float bulletSpeed;
    public float fireRate;
    public float bulletRotSpeed;
    bool isRotate = false;
    bool isRotateAttack = false;

    [Space]
    [Header("Hand Attack")]
    public GameObject leftHand;
    public GameObject rightHand;
    public GameObject laser;
    public Transform leftHandPos;
    public Transform rightHandPos;
    public Animator laserLeft;
    public Animator laserRight;
    public AudioSource laserSFX;

    bool moveLeft = false;
    bool moveRight = false;
    Vector3 playerPos;

    [Space]
    [Header("follow spike attack")]
    public GameObject prefabSpike;
    public Transform[] spikePos;
    public float spikeSpeed;
    public AudioSource spikeSFX;
    public AudioSource spikeMove;
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

        //Debug
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            if (isRotateAttack == false)
            {
                StartCoroutine("rotateAttack");
            }
        }
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            if (isSpikeAttack == false)
            {
                StartCoroutine(spikeAttack());
            }
        }
        if(Input.GetKeyDown(KeyCode.Keypad3))
        {
            StartCoroutine(laserAttack());
        }

        if(moveRight == true)
        {
            rightHand.transform.position = Vector3.Lerp(rightHand.transform.position, new Vector2(rightHand.transform.position.x, playerPos.y), 5f * Time.deltaTime);
        }
        if(moveLeft == true)
        {
            leftHand.transform.position = Vector3.Lerp(leftHand.transform.position, new Vector2(leftHand.transform.position.x, playerPos.y), 5f * Time.deltaTime);
        }
    }

    IEnumerator rotateAttack()
    {
        isRotateAttack = true;
        isRotate = true;
        int i = 0;
        while(i < bulletCount) {
            rotSFX.Play();
            rotateShooting();
            i++;
            yield return new WaitForSeconds(fireRate);
        }

        //isRotateAttack = false;
        isRotate = false;
        rotSFX.Stop();
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
        spikeSFX.Play();
        GameObject clone = Instantiate(prefabSpike, spikePos[0].position, Quaternion.identity);
        yield return new WaitForSeconds(0.1f);
        GameObject clone1 = Instantiate(prefabSpike, spikePos[1].position, Quaternion.identity);
        yield return new WaitForSeconds(0.1f);
        GameObject clone2 = Instantiate(prefabSpike, spikePos[2].position, Quaternion.identity);
        yield return new WaitForSeconds(0.1f);
        GameObject clone3 = Instantiate(prefabSpike, spikePos[3].position, Quaternion.identity);
        yield return new WaitForSeconds(0.1f);
        GameObject clone4 = Instantiate(prefabSpike, spikePos[4].position, Quaternion.identity);


        yield return new WaitForSeconds(2f);
        spikeRot_(0);
        //attack 1
        spikeMove.Play();
        spikePos[0].rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        Rigidbody2D crb = clone.GetComponent<Rigidbody2D>();
        crb.AddForce(spikePos[0].up * spikeSpeed * Time.deltaTime, ForceMode2D.Impulse);
        crb.velocity = Vector2.ClampMagnitude(crb.velocity, spikeSpeed);
        clone.GetComponent<Transform>().rotation = spikeRot;
        yield return new WaitForSeconds(0.7f);
        spikeRot_(1);
        //attack 2
        spikeMove.Play();
        spikePos[1].rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        Rigidbody2D crb1 = clone1.GetComponent<Rigidbody2D>();
        crb1.AddForce(spikePos[1].up * spikeSpeed * Time.deltaTime, ForceMode2D.Impulse);
        crb1.velocity = Vector2.ClampMagnitude(crb1.velocity, spikeSpeed);
        clone1.GetComponent<Transform>().rotation = spikeRot;

        yield return new WaitForSeconds(0.7f);
        spikeRot_(2);
        //attack 3
        spikeMove.Play();
        spikePos[2].rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        Rigidbody2D crb2 = clone2.GetComponent<Rigidbody2D>();
        crb2.AddForce(spikePos[2].up * spikeSpeed * Time.deltaTime, ForceMode2D.Impulse);
        crb2.velocity = Vector2.ClampMagnitude(crb2.velocity, spikeSpeed);
        clone2.GetComponent<Transform>().rotation = spikeRot;

        yield return new WaitForSeconds(0.7f);
        spikeRot_(3);
        //attack 4
        spikeMove.Play();
        spikePos[3].rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        Rigidbody2D crb3 = clone3.GetComponent<Rigidbody2D>();
        crb3.AddForce(spikePos[3].up * spikeSpeed * Time.deltaTime, ForceMode2D.Impulse);
        crb3.velocity = Vector2.ClampMagnitude(crb3.velocity, spikeSpeed);
        clone3.GetComponent<Transform>().rotation = spikeRot;

        yield return new WaitForSeconds(0.7f);
        spikeRot_(4);
        //attack 5
        spikeMove.Play();
        spikePos[4].rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        Rigidbody2D crb4 = clone4.GetComponent<Rigidbody2D>();
        crb4.AddForce(spikePos[4].up * spikeSpeed, ForceMode2D.Impulse);
        crb4.velocity = Vector2.ClampMagnitude(crb4.velocity, spikeSpeed);
        clone4.GetComponent<Transform>().rotation = spikeRot;

        yield return new WaitForSeconds(0.5f);
        bodyAnim.Play("bossIdle");
        isSpikeAttack = false;
        spikeSFX.Stop();
    }

    private void spikeRot_(int i)
    {
        dir = player.transform.position - spikePos[i].transform.position;
        angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
        spikeRot = Quaternion.AngleAxis(angle - 180, Vector3.forward);
    }

    IEnumerator laserAttack()
    {
        laserLeft.Play("BossHandAttack");
        laserRight.Play("BossHandAttack");
        moveLeft = true;
        playerPos = player.transform.position;
        yield return new WaitForSeconds(1f);
        laserSFX.Play();
        laserShoot(false);
        yield return new WaitForSeconds(1f);
        moveLeft = false;


        moveRight = true;
        playerPos = player.transform.position;
        yield return new WaitForSeconds(1f);
        laserSFX.Play();
        laserShoot(true);
        yield return new WaitForSeconds(1f);
        moveRight = false;


        moveLeft = true;
        playerPos = player.transform.position;
        yield return new WaitForSeconds(1f);
        laserSFX.Play();
        laserShoot(false);
        yield return new WaitForSeconds(1f);
        moveLeft = false;


        moveRight = true;
        playerPos = player.transform.position;
        yield return new WaitForSeconds(1f);
        laserSFX.Play();
        laserShoot(true);
        yield return new WaitForSeconds(1f);
        moveRight = false;

        yield return new WaitForSeconds(3f);
        laserLeft.Play("BossHandIdle");
        laserRight.Play("BossHandIdle");
    }

    private void laserShoot(bool isRight)
    {
        if(isRight == true)
        {
           GameObject clone1 = Instantiate(laser, rightHandPos.transform.position, Quaternion.identity);
            Destroy(clone1, 3f);
        }
        else
        {
           GameObject clone = Instantiate(laser, leftHandPos.transform.position, Quaternion.identity);
            clone.transform.localScale = new Vector2(-1, 1);
            Destroy(clone, 3f);
        }
    }
}
