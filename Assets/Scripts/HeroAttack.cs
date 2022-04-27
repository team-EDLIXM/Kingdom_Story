using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroAttack : MonoBehaviour
{
    public float respiteTime = 0.5f;
    public bool isRespite = false;
    public float fireballReloadTime = 2f;
    private bool isReload = false;

    public Animator anim;
    public Transform attackPos;
    public float attackRange;
    public LayerMask enemy;
    public Transform fireballPos;
    public Transform fireball;

    private void Update()
    {
        if (Time.timeScale == 0) return;

        if (Input.GetMouseButton(0) && !isRespite)
        {
            anim.SetTrigger("Attack");
            AudioManager.instance.PlaySFX(3);
            StartCoroutine(RespiteTime());
        }
        else if (Input.GetMouseButton(1) && !isReload)
        {
            anim.SetTrigger("Fire");

            StartCoroutine(FireballReloadTime());
        }
    }

    private IEnumerator FireballReloadTime()
    {
        isReload = true;
        yield return new WaitForSeconds(fireballReloadTime);
        isReload = false;
    }

    private IEnumerator RespiteTime()
    {
        isRespite = true;
        yield return new WaitForSeconds(respiteTime);
        isRespite = false;
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
