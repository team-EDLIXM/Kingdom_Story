using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroAttack : MonoBehaviour
{
    public float respiteTime = 0.5f;

    public bool isRespite = false;
    public bool isAttacking;

    public Animator anim;
    public float activeAttackTime = 0.5f;
    public LayerMask enemy;

    private Dictionary<string, Collider2D> attacks;
    private ContactFilter2D filter;
    private string currentAttack;
    
    private void Start()
    {
        attacks = new Dictionary<string, Collider2D>();
        foreach (var x in GetComponentsInChildren<Collider2D>())
            attacks[x.name] = x;

        filter = new ContactFilter2D().NoFilter();
        filter.SetLayerMask(enemy);
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
                    currentAttack = "airNeutralAttack";
            }
            else
            {
                if (verticalPress > 0)
                    currentAttack = "neutralAttack";
                else if (horizontalPress != 0)
                    currentAttack = "sideAttack";
                else
                    currentAttack = "neutralAttack";
            }

            AudioManager.instance.PlaySFX(3);
            anim.SetTrigger(currentAttack);
            StartCoroutine(RespiteTime());
            StartCoroutine(AttackTime());
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
            st.TakeDamage(1);
            
            var v = new Vector2(enemies[i].transform.position.x - transform.position.x,
                enemies[i].transform.position.y - transform.position.y);
            st.Push(v);
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

    /*private IEnumerator FireballReloadTime()
    {
        isReload = true;
        yield return new WaitForSeconds(fireballReloadTime);
        isReload = false;
    }*/
}
