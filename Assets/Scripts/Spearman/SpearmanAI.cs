using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearmanAI : MonoBehaviour
{
    public bool check_AttackUp;
    public bool check_AttackForward;
    public Animator animator;
    Rigidbody2D rb;
    float speed;
    public float dashTime;
    public float dashReloadTime;
    public bool isDash = false;
    public bool dashReloading = false;

    void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        speed = GetComponent<Stats>().speed;
    }

    void Update()
    {
        if (!isDash && !dashReloading)
        { 
            Dash();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !isDash)
            AttackUp();
    }

    public void Dash()
    {
        animator.SetBool("isDash", true);
        StartCoroutine(DashTimer());
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }

    IEnumerator DashTimer()
    {
        isDash = true;
        yield return new WaitForSeconds(dashTime);
        rb.velocity = new Vector2(0, rb.velocity.y);
        animator.SetBool("isDash", false);
        isDash = false;
        StartCoroutine(DashReloadTimer());
    }

    IEnumerator DashReloadTimer()
    {
        dashReloading = true;
        yield return new WaitForSeconds(dashReloadTime);
        dashReloading = false;
    }

    public void AttackUp()
    {
        animator.SetBool("isAttackUp", true);
        StartCoroutine(AttackUpTimer());
    }

    IEnumerator AttackUpTimer()
    {
        yield return new WaitForSeconds(0.5f);
        animator.SetBool("isAttackUp", false);
    }
}
