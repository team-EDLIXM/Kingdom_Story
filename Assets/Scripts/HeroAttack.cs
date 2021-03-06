using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroAttack : MonoBehaviour
{
    public float respiteTime = 0.5f;
    public bool isRespite = false;
    public bool isAttacking;
    public float fireballReloadTime = 2f;
    private bool isReload = false;
    public bool FireballUnlocked;

    public Animator anim;
    public float activeAttackTime = 0.5f;
    public LayerMask enemy;

    private Dictionary<string, Collider2D> attacks;
    private ContactFilter2D filter;
    private string currentAttack;
    private Stats _stats;

    public Transform fireballPos;
    public Transform fireball;

    private void Start()
    {
        attacks = new Dictionary<string, Collider2D>();
        foreach (var x in GetComponentsInChildren<Collider2D>())
            attacks[x.name] = x;

        filter = new ContactFilter2D().NoFilter();
        filter.SetLayerMask(enemy);

        _stats = GetComponent<Stats>();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        if (isAttacking)
            Gizmos.DrawCube(transform.position, new Vector3(1, 1, 1));
    }

    private void Update()
    {
        if (Time.timeScale == 0) return;

        if (Input.GetMouseButton(0) && !isRespite && !isAttacking)
        {
            float verticalPress = Input.GetAxisRaw("Vertical");
            float horizontalPress = Input.GetAxisRaw("Horizontal");

            if (!GetComponent<hero>().isGrounded)
            {
                if (verticalPress != 0)
                {
                    if (verticalPress > 0)
                        currentAttack = "airNeutralAttack";
                    if (verticalPress < 0)
                        currentAttack = "airBottomAttack";
                }
                else if (horizontalPress != 0)
                    currentAttack = "airSideAttack";
                else
                    currentAttack = "airSideAttack";
            }
            else
            {
                if (verticalPress > 0)
                    currentAttack = "neutralAttack";
                else if (horizontalPress != 0)
                    currentAttack = "sideAttack";
                else
                    currentAttack = "sideAttack";
            }

            AudioManager.instance.PlaySFX(3);
            anim.SetTrigger(currentAttack);
            StartCoroutine(RespiteTime());
            StartCoroutine(AttackTime());
        }
        else if (FireballUnlocked && Input.GetMouseButton(1) && !isReload)
        {
            anim.SetTrigger("Fire");

            StartCoroutine(FireballReloadTime());
        }

        if (isAttacking)
            Attack(currentAttack);

    }

    private void Attack(string attackType)
    {
        currentAttack = attackType;
        var enemies = new List<Collider2D>();
        for (int i = 0; i < attacks[attackType].OverlapCollider(filter, enemies); ++i)
        {
            var st = enemies[i].GetComponent<Stats>();
            st.TakeDamage(_stats.dmg);
            
            var v = new Vector2(enemies[i].transform.position.x - transform.position.x,
                enemies[i].transform.position.y - transform.position.y);
            st.Push(v);

            if(attackType == "airBottomAttack") GetComponent<Rigidbody2D>().velocity = Vector2.up * 15;
        }
    }

    private IEnumerator AttackTime()
    {
        isAttacking = true;
        yield return new WaitForSeconds(activeAttackTime);
        isAttacking = false;
    }

    private IEnumerator RespiteTime()
    {
        isRespite = true;
        yield return new WaitForSeconds(respiteTime);
        isRespite = false;
    }

    private IEnumerator FireballReloadTime()
    {
        isReload = true;
        yield return new WaitForSeconds(fireballReloadTime);
        isReload = false;
    }

    private void OnFire()
    {
        var newFireball = Instantiate(fireball) as Transform;

        newFireball.position = fireballPos.position;

        MoveScript move = newFireball.gameObject.GetComponent<MoveScript>();

        if (move != null)
        {
            move.direction = this.transform.right;
        }
    }
}
