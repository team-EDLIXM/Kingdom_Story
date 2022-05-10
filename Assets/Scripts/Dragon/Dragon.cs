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
    public Transform fireRightPoint;
    public Transform fireMiddlePoint;
    public Rigidbody2D fireball;
    public float fireballSpeed;
    public float fireSpeed;
    public float fireDestroyTime;

    public int magicalSphereAttackCountMax;
    public int magicalSphereAttackCount = 0;
    public Rigidbody2D magicalSphere;
    public Transform magicalSpherePoint;

    public int portalAttackCountMax;
    public int portalAttackCount = 0;
    public Transform PortalBottom;
    public Transform PortalTop;
    public Rigidbody2D lightning;
    public float lightningSpeed;


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
        if (!animator.GetBool("stage2Done"))
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
            if (headRight.GetComponent<Stats>().health <= 0)
                animator.SetTrigger("stage2Done");
        }
        else 
        {
            if (fireAttackCount == fireAttackCountMax)
            {
                animator.SetBool("fireAttackDone", true);
            }
            if (magicalSphereAttackCount == magicalSphereAttackCountMax)
            {
                animator.SetBool("magicalSphereAttackDone", true);
            }
            if (portalAttackCount == portalAttackCountMax)
            {
                animator.SetBool("fireAttackDone", false);
                fireAttackCount = 0;
                animator.SetBool("magicalSphereAttackDone", false);
                magicalSphereAttackCount = 0;
                animator.SetBool("portalAttack", false);
                portalAttackCount = 0;
            }

            if (headMiddle.GetComponent<Stats>().health <= 0)
                animator.SetTrigger("stage3Done");
        }
    }

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
        Rigidbody2D cloneLeft = Instantiate(stompWave, stompWavePoint.transform.position, Quaternion.Euler(0, 180, 0)) as Rigidbody2D;
        //cloneLeft.GetComponent<SpriteRenderer>().flipX = true;
        cloneLeft.velocity = -stompWavePoint.transform.right * stompWaveSpeed;
        //cloneLeft.transform.right = stompWavePoint.transform.right;
        cloneLeft.GetComponent<StompWave>().destroyTime = stompWaveDestroyTime;
        cloneLeft.GetComponent<StompWave>().dmg = damage;

        Rigidbody2D cloneRight = Instantiate(stompWave, stompWavePoint.transform.position, Quaternion.identity) as Rigidbody2D;
        //cloneRight.GetComponent<SpriteRenderer>().flipX = true;
        cloneRight.velocity = stompWavePoint.transform.right * stompWaveSpeed;
        //cloneRight.transform.right = stompWavePoint.transform.right;
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

    public void FireRightHead()
    {
        Rigidbody2D clone = Instantiate(fire, fireRightPoint.transform.position, Quaternion.Euler(0, 180, 0)) as Rigidbody2D;
        //clone.transform.rotation = Quaternion.Euler(0, 180, 0);
        clone.velocity = -fireRightPoint.transform.right * fireSpeed;
        //clone.transform.right = fireRightPoint.transform.right;
        clone.GetComponent<DragonFire>().destroyTime = fireDestroyTime;
        clone.GetComponent<DragonFire>().dmg = damage;
    }

    public void FireMiddleHead()
    {
        Rigidbody2D clone = Instantiate(fireball, fireMiddlePoint.transform.position, Quaternion.identity) as Rigidbody2D;
        //transform.position = Vector2.MoveTowards(transform.position, new Vector2(x, y + 1), stats.speed / 55f);
        //clone.transform.right = fireRightPoint.transform.right;
        var heading = player.transform.position - fireMiddlePoint.transform.position;
        var distance = heading.magnitude;
        var direction = heading / distance; // This is now the normalized direction.
        clone.velocity = direction * fireballSpeed;
        clone.GetComponent<DragonFireball>().dmg = damage;
    }
    
    public void MagicalSphereAttack()
    {
        Rigidbody2D clone = Instantiate(magicalSphere, magicalSpherePoint.transform.position, Quaternion.identity) as Rigidbody2D;
        clone.GetComponent<DragonMagicalSphere>().dmg = damage;
    }

    public void PushPlayer()
    {
        //player.GetComponent<Rigidbody2D>().AddForce(new Vector2(-100f, 0), ForceMode2D.Impulse);
        //player.GetComponent<Rigidbody2D>().velocity = new Vector2(-10f, 0);
        //player.GetComponent<Rigidbody2D>().MovePosition(headLeft.transform.position);
        // idk how, so the portal will kill player, if he is in right part of portal
        player.GetComponent<Stats>().Push(new Vector2(-2, 0));
    }

    public IEnumerator PortalAttack()
    {
        int lightningCount = Random.Range(5, 11);
        float time = 5f / lightningCount;
        int curLightning = 0;
        var pos = PortalBottom.position;
        while (curLightning <= lightningCount)
        {
            float y = Random.Range(PortalBottom.position.y, PortalTop.position.y);
            Rigidbody2D clone = Instantiate(lightning, new Vector3(pos.x, y, pos.z), Quaternion.identity) as Rigidbody2D;
            clone.GetComponent<DragonLightning>().dmg = damage;
            clone.velocity = new Vector2(-lightningSpeed, 0);
            yield return new WaitForSeconds(time);
            curLightning++;
        }
    }
}
