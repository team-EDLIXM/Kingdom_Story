using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : MonoBehaviour
{
    private GameObject player;
    private Animator animator;

    public int damage;
    public GameObject headLeft;
    public GameObject headMiddle;
    public GameObject headRight;
    public bool isInvulnerable = false;
    public float InvulnerableTime = 0.5f;
    public float IdleTimer;

    public int headHitCountMax;
    public int headHitCount = 0;
    //public bool headHitDone = false;

    public int stompCountMax;
    public int stompCount = 0;
    public float stompWaveSpeed;
    public Rigidbody2D stompWave;
    public Transform stompWavePoint;
    public float stompWaveDestroyTime;

    public int fireAttackCountMax;
    public int fireAttackCount = 0;
    public Rigidbody2D fire;
    public Transform fireLeftPoint;
    public float fireSpeed;
    public float fireDestroyTime;


    private void Awake()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        headLeft.GetComponent<Stats>().isInvulnerable = true;
        headMiddle.GetComponent<Stats>().isInvulnerable = true;
        headRight.GetComponent<Stats>().isInvulnerable = true;
    }

    private void Update()
    {
        if (headHitCount == headHitCountMax)
        {
            animator.SetBool("headHitDone", true);
        }
        if (stompCount == stompCountMax)
        {
            animator.SetBool("stompDone", true);
        }
        if (fireAttackCount == fireAttackCountMax)
        {
            animator.SetInteger("head", 0);
            animator.SetBool("headHitDone", false);
            headHitCount = 0;
            animator.SetBool("stompDone", false);
            stompCount = 0;
            animator.SetBool("fireAttack", false);
            fireAttackCount = 0;
        }
        if (headLeft.GetComponent<Stats>().health <= 0)
            animator.SetTrigger("stage1Done");
    }

    //public void TakeDamage(int head, int dmg)
    //{
    //    if (!isInvulnerable)
    //    {
    //        switch (head)
    //        {
    //            case 1: 
    //                //headLeftHealth -= dmg;
    //                break;
    //            case 2:
    //                headMiddleHealth -= dmg;
    //                break;
    //            case 3:
    //                headRightHealth -= dmg;
    //                break;
    //        }
    //        StartCoroutine(Invulnerability());
    //    }
    //}
    //private IEnumerator Invulnerability()
    //{
    //    this.GetComponent<SpriteRenderer>().color = new Color(
    //        this.GetComponent<SpriteRenderer>().color.r,
    //        this.GetComponent<SpriteRenderer>().color.g,
    //        this.GetComponent<SpriteRenderer>().color.b, 0.5f);
    //    isInvulnerable = true;
    //    yield return new WaitForSeconds(InvulnerableTime);
    //    this.GetComponent<SpriteRenderer>().color = new Color(
    //        this.GetComponent<SpriteRenderer>().color.r,
    //        this.GetComponent<SpriteRenderer>().color.g,
    //        this.GetComponent<SpriteRenderer>().color.b, 1f);
    //    isInvulnerable = false;
    //}

    public void HeadLeftHit()
    {
        if (headLeft.GetComponent<playerCheck>().playerIsInTrigger)
            player.GetComponent<Stats>().TakeDamage(damage);
    }
    public void HeadMiddleHit()
    {
        if (headMiddle.GetComponent<playerCheck>().playerIsInTrigger)
            player.GetComponent<Stats>().TakeDamage(damage);
    }
    public void HeadRightHit()
    {
        if (headRight.GetComponent<playerCheck>().playerIsInTrigger)
            player.GetComponent<Stats>().TakeDamage(damage);
    }
    public int ChooseHead()
    {
        float playerPos = player.transform.position.x;
        float headLeftDx = Mathf.Abs(playerPos - headLeft.transform.position.x);
        float headMiddleDx = Mathf.Abs(playerPos - headMiddle.transform.position.x);
        float headRightDx = Mathf.Abs(playerPos - headRight.transform.position.x);
        float min = Mathf.Min(headLeftDx, headMiddleDx, headRightDx);
        if (headLeft.GetComponent<Stats>().health > 0 && headLeftDx == min)
            return 1;
        else if (headMiddle.GetComponent<Stats>().health > 0 && headMiddleDx < headRightDx)
            return 2;
        else if (headRight.GetComponent<Stats>().health > 0)
            return 3;
        else
            return 0;
    }

    public void Stomp()
    {
        Rigidbody2D cloneLeft = Instantiate(stompWave, stompWavePoint.transform.position, Quaternion.identity) as Rigidbody2D;
        cloneLeft.GetComponent<SpriteRenderer>().flipX = true;
        cloneLeft.velocity = -stompWavePoint.transform.right * stompWaveSpeed;
        cloneLeft.transform.right = stompWavePoint.transform.right;
        cloneLeft.GetComponent<StompWave>().destroyTime = stompWaveDestroyTime;
        cloneLeft.GetComponent<StompWave>().dmg = damage;

        Rigidbody2D cloneRight = Instantiate(stompWave, stompWavePoint.transform.position, Quaternion.identity) as Rigidbody2D;
        cloneRight.GetComponent<SpriteRenderer>().flipX = true;
        cloneRight.velocity = stompWavePoint.transform.right * stompWaveSpeed;
        cloneRight.transform.right = stompWavePoint.transform.right;
        cloneRight.GetComponent<StompWave>().destroyTime = stompWaveDestroyTime;
        cloneRight.GetComponent<StompWave>().dmg = damage;
    }

    public void FireLeftHead()
    {
        Rigidbody2D clone = Instantiate(fire, fireLeftPoint.transform.position, Quaternion.identity) as Rigidbody2D;
        clone.velocity = fireLeftPoint.transform.right * fireSpeed;
        clone.transform.right = fireLeftPoint.transform.right;
        clone.GetComponent<DragonFire>().destroyTime = fireDestroyTime;
        clone.GetComponent<DragonFire>().dmg = damage;
    }
}
