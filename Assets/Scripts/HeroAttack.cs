using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroAttack : MonoBehaviour
{
    public float StartTimeBtwHits;
    private float TimeBtwHits;

    public Animator anim;
    public Transform attackPos;
    public float attackRange;
    public LayerMask enemy;

    // Update is called once per frame
    /*void Update()
    {
        if (Time.timeScale == 0) return;
        
        if (Input.GetMouseButton(0))
         {
             anim.Play("Player_Attack");
            AudioManager.instance.PlaySFX(3);
            StartCoroutine(DoAttack());
         }
        
    }

    IEnumerator DoAttack()
    {
        AttackHitbox.SetActive(true);
        yield return new WaitForSeconds(0.7f);
        AttackHitbox.SetActive(false);

        isAttacking = false;
    }*/

    private void Update()
    {
        if (TimeBtwHits <= 0)
        {
            if (Input.GetMouseButton(0))
            {
                anim.SetTrigger("Attack");
                AudioManager.instance.PlaySFX(3);
            }
            TimeBtwHits = StartTimeBtwHits;
        }
        else
        {
            TimeBtwHits -= StartTimeBtwHits;
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }

    private void OnAttack()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPos.position, attackRange, enemy);
        for (int i = 0; i < enemies.Length; ++i)
        {
            enemies[i].GetComponent<Stats>().TakeDamage(1);
        }
    }

}
