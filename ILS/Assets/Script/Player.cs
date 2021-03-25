using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    [Header("Skills")]
    private float speed;
    public float dashSpeed = 2f;
    public GameObject botSkillBtn;
    public GameObject topSkillBtn;
    [SerializeField] private CapsuleCollider2D skillCollider;
    [SerializeField] AudioSource tpSFX;
    [SerializeField] AudioSource shootSFX;
    public GameObject prefabTornado;

    [Header("Player")]
    [SerializeField] private GameObject textPopup;
    [SerializeField] private Joystick variableJoystick;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator anim;
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private ParticleSystem particle;
    private Collider2D col;
    [SerializeField] ParticleSystem lvlUp;
    [SerializeField] AudioSource levelUpSFX;

    [Header("Attack Variables")]
    public GameObject aimRot;
    public GameObject fireball;
    public Transform aimPos;
    public GameObject atkBtn;
    public float rangeOfAim;

    private GameObject animTP;
    private GameObject skillChild;

    
    private bool isTeleportCD = false;
    private bool isTornadoCD = false;
    private float angle;
    private bool isTeleporting = false;
    private bool isTornado = false;
    private float atkTimer = 0;
    private float health;
    private float mana;
    private int enemyCount = 0;
    private float enemyCountTime = 30f;
    private float enemyTimer = 0f;
    private bool isAllEnemyDead = false;
    private bool isHpRegen = false;
    private bool isManaRegen = false;
    private void Awake()
    {

    }
    private void Start()
    {
        var particleEmission = lvlUp.emission;
        particleEmission.enabled = false;

        speed = PlayerPrefs.GetFloat("movementSpeed");
        health = PlayerPrefs.GetFloat("health");
        mana = PlayerPrefs.GetFloat("mana");
        PlayerPrefs.SetFloat("currentHp", health);
        atkTimer = PlayerPrefs.GetFloat("attackSpeed");

        animTP = GameObject.FindGameObjectWithTag("tpChildren");
        skillChild = GameObject.FindGameObjectWithTag("SkillChildren");
        col = GetComponent<Collider2D>();

        Debug.Log("Current EXP " + PlayerPrefs.GetFloat("EXP"));
        Debug.Log("Exp To Level Up " + PlayerPrefs.GetFloat("ExpToLevelUp"));
        Debug.Log("Level " + PlayerPrefs.GetFloat("Level"));
    }
    private void Update()
    {
        tpSFX.volume = (PlayerPrefs.GetFloat("sfxValue") / 100);
        shootSFX.volume = (PlayerPrefs.GetFloat("sfxValue") / 100);
        levelUpSFX.volume = (PlayerPrefs.GetFloat("sfxValue") / 100);

        transform.parent.position = transform.position - transform.localPosition;

        //debug
        if(Input.GetKeyDown(KeyCode.Space))
        {
            dashBtn();
        }
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            skillTornadoBtn();
        }
        if(Input.GetKeyDown(KeyCode.C))
        {
            shoot();
        }


        //ATTACK SPEED. ATK TIMER
        atkTimer += Time.deltaTime;
        if (atkTimer >= PlayerPrefs.GetFloat("attackSpeed"))
        {
            atkBtn.GetComponent<Image>().color = Color.white;
            atkTimer = PlayerPrefs.GetFloat("attackSpeed");
        }
        else if (atkTimer < 0)
        {
            atkTimer = 0;
        }
        else {
            atkBtn.GetComponent<Image>().color = Color.black;
        }

        if(isTornadoCD == false)
        {
            botSkillBtn.GetComponent<Image>().color = Color.white;
        }
        else
        {
            botSkillBtn.GetComponent<Image>().color = Color.black;
        }

        if(isTeleportCD == false)
        {
            topSkillBtn.GetComponent<Image>().color = Color.white;
        } 
        else
        {
            topSkillBtn.GetComponent<Image>().color = Color.black;
        }

        // E N E M Y   F U N C T I O N S
        //Finding Enemy
        Invoke("findEnemy", 3f);

        //ENEMY COUNT
        enemyTimer++;
        if(enemyTimer >= enemyCountTime)
        {
            enemyCount = Enemy.enemyList.Count;
            Debug.Log("Enemy Count: " + enemyCount);
            enemyTimer -= enemyCountTime;
        }

        //enemy all dead function
        StartCoroutine(enemyAllDead());
        //E N D   O F   E N E M Y    F U N C T I O N


        //particle
        if (Mathf.Abs(rb.velocity.x) != 0 || Mathf.Abs(rb.velocity.y) != 0)
        {
            if (!particle.isEmitting)
                particle.Play();
        }
        else if (particle.isEmitting)
        {
            particle.Stop(true, ParticleSystemStopBehavior.StopEmitting);
        }

        //HP
        //MANA
        //EXP
        PlayerPrefs.SetFloat("currentHp", health);
        PlayerPrefs.SetFloat("currentMana", mana);
        PlayerPrefs.Save();

        //Regeneration
        if(health < PlayerPrefs.GetFloat("health") && isHpRegen == false)
        {
            StartCoroutine("hpRegen");
        }
        if(mana < PlayerPrefs.GetFloat("mana") && isManaRegen == false)
        {
            StartCoroutine("manaRegen");
        }

        //fixes
        if(health > PlayerPrefs.GetFloat("health"))
        {
            health = PlayerPrefs.GetFloat("health");
        }

        if(mana > PlayerPrefs.GetFloat("mana"))
        {
            mana = PlayerPrefs.GetFloat("mana");
        }
    }
    public void FixedUpdate()
    {
        //movement
        if (variableJoystick.Horizontal <= -0.4f || variableJoystick.Vertical <= -0.4f ||
            variableJoystick.Horizontal >= 0.4f || variableJoystick.Vertical >= 0.4f)
        {
            if (isTeleporting == true)
            {
                rb.velocity = Vector3.zero;
            }
            else
            {
                rb.velocity = new Vector2(variableJoystick.Horizontal * speed, variableJoystick.Vertical * speed);
            }
        }
        else
        {
            rb.velocity = Vector3.zero;
        }

        if (variableJoystick.Horizontal < 0)
        {
            //transform.localScale = new Vector3(2, 2, 2);
            sr.flipX = false;
        }
        else if (variableJoystick.Horizontal > 0)
        {
            //transform.localScale = new Vector3(-2, 2, 2);
            sr.flipX = true;
        }



        //animation
        if (Mathf.Abs(rb.velocity.x) > 0 || Mathf.Abs(rb.velocity.y) > 0)
        {
            if (isTeleporting != true)
            {
                anim.Play("Walking");
            }
        }
        else
        {
            //anim.Play("IdleNewWiz");
        }


    }


    
    //function for shooting magic

    public void shoot()
    {
        if (atkTimer >= PlayerPrefs.GetFloat("attackSpeed"))
        {
            shootSFX.Play();
            anim.Play("Attack");
            GameObject clone = Instantiate(fireball,aimRot.transform.position, aimRot.transform.rotation);
            Rigidbody2D crb = clone.GetComponent<Rigidbody2D>();
            crb.AddForce(aimPos.right * PlayerPrefs.GetFloat("magicSpeed"), ForceMode2D.Impulse);
            crb.velocity = Vector2.ClampMagnitude(crb.velocity, PlayerPrefs.GetFloat("magicSpeed"));
            Destroy(clone, 10f);
            atkTimer -= PlayerPrefs.GetFloat("attackSpeed");

        }
    }


    //take damage when hit
    public void playerTakeDamage(float ammount)
    {
        health -= ammount;
        if (PlayerPrefs.GetInt("isDamageInd") == 0)
        {
            GameObject clone = Instantiate(textPopup, new Vector2(transform.position.x, transform.position.y + 2), Quaternion.identity);
            clone.GetComponentInChildren<TextMeshPro>().text = "" + ammount.ToString("F0");
            clone.GetComponentInChildren<TextMeshPro>().color = Color.red;
            clone.transform.parent = transform.parent;
            Destroy(clone, 3f);
        }

        if (health <= 0)
        {
            dead();
        }
    }

    public void playerRestoreHP(float hpPots)
    {
        health += hpPots;
        if (PlayerPrefs.GetInt("isHealth") == 0)
        {
            GameObject clone = Instantiate(textPopup, new Vector2(transform.position.x, transform.position.y + 2), Quaternion.identity);
            clone.GetComponentInChildren<TextMeshPro>().text = "" + hpPots.ToString("F0");
            clone.GetComponentInChildren<TextMeshPro>().color = Color.green;
            clone.transform.parent = transform.parent;
            Destroy(clone, 3f);
        }
    }

    public void playerRestoreMana(float manaPots)
    {
        mana += manaPots;
        if (PlayerPrefs.GetInt("isMana") == 0)
        {
            GameObject clone = Instantiate(textPopup, new Vector2(transform.position.x, transform.position.y + 2), Quaternion.identity);
            clone.GetComponentInChildren<TextMeshPro>().text = "" + manaPots.ToString("F0");
            clone.GetComponentInChildren<TextMeshPro>().color = Color.blue;
            clone.transform.parent = transform.parent;
            Destroy(clone, 3f);
        }
    }

    public void coinPickup(int coinsCount)
    {
        GameObject clone = Instantiate(textPopup, new Vector2(transform.position.x, transform.position.y + 2), Quaternion.identity);
        clone.GetComponentInChildren<TextMeshPro>().text = "" + coinsCount.ToString("F0");
        clone.GetComponentInChildren<TextMeshPro>().color = Color.yellow;
        clone.transform.parent = transform.parent;
        Destroy(clone, 3f);
    }

    //delay function for enemy
    void findEnemy()
    {

        foreach (Enemy enemy in Enemy.GetEnemyList())
        {

            if (Vector3.Distance(transform.position, enemy.transform.position) < rangeOfAim)
            {
                Vector3 dir = enemy.transform.position - transform.position;
                angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                aimRot.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            }
        }
    }
    //dead function
    private void dead()
    {

    }

    //show range on scene
    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(this.transform.position, rangeOfAim);
    }


    //dash btn
    public void dashBtn()
    {
        if (mana >= 10)
        {
            if (isTeleportCD == false)
            {
                isTeleporting = true;
                StartCoroutine("playerDash");
                StartCoroutine("skillCDTeleport");
            }
        }
    }

    //Skill Tornado Btn
    public void skillTornadoBtn()
    {
        if (mana >= 50)
        {
            if (isTornadoCD == false)
            {
                isTornado = true;
                StartCoroutine("playerSkill");
                StartCoroutine("skillCDTornado");
            }
        }
    }

    public void levelUp()
    {
        StartCoroutine("lvlUpDelay");
    }

    IEnumerator lvlUpDelay()
    {
        var particleEmission = lvlUp.emission;
        particleEmission.enabled = true;
        lvlUp.Play();
        levelUpSFX.Play();

        yield return new WaitForSeconds(2f);
        particleEmission.enabled = false;
    }


    //Add delay on finding if every enemy is dead
    IEnumerator enemyAllDead()
    {
        yield return new WaitForSeconds(5f);

        if (enemyCount <= 0 && isAllEnemyDead == false)
        {
            Debug.Log("All of the enemy is dead");
            isAllEnemyDead = true;
        }
    }

    IEnumerator playerDash()
    {
        mana -= 10;
        tpSFX.Play();
        isTeleporting = true;
        anim.Play("TP animation V2");
        animTP.GetComponent<Animator>().Play("tp new v3");
        Physics2D.IgnoreLayerCollision(15, 8, true);

        yield return new WaitForSeconds(0.400f);

        rb.AddForce(new Vector2(variableJoystick.Horizontal, variableJoystick.Vertical) * dashSpeed);
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, 1f);

        yield return new WaitForSeconds(0.200f);
        Physics2D.IgnoreLayerCollision(15, 8, false);
        isTeleporting = false;
    }

    IEnumerator playerSkill()
    {
        mana -= 50f;
        GameObject clone = Instantiate(prefabTornado, aimRot.transform.position, Quaternion.identity);
        Rigidbody2D crb1 = clone.GetComponent<Rigidbody2D>();
        crb1.AddForce(aimPos.right * 3f, ForceMode2D.Impulse);
        crb1.velocity = Vector2.ClampMagnitude(crb1.velocity, 3f);
        Destroy(clone, 10f);

        yield return null;
    }

    IEnumerator skillCDTornado()
    {
        isTornadoCD = true;
        yield return new WaitForSeconds(5f);
        isTornadoCD = false;
    }

    IEnumerator skillCDTeleport()
    {
        isTeleportCD = true;
        yield return new WaitForSeconds(1f);
        isTeleportCD = false;
    }

    IEnumerator hpRegen()
    {
        isHpRegen = true;
        health += PlayerPrefs.GetFloat("healthRegen");
        Debug.Log("hp regen: " + PlayerPrefs.GetFloat("healthRegen"));
        yield return new WaitForSeconds(1);
        isHpRegen = false;
    }

    IEnumerator manaRegen()
    {
        isManaRegen = true;
        mana += PlayerPrefs.GetFloat("manaRegen");
        Debug.Log("mana regen: " + PlayerPrefs.GetFloat("manaRegen"));
        yield return new WaitForSeconds(1);
        isManaRegen = false;
    }

}