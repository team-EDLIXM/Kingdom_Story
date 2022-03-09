using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearmanAI : MonoBehaviour
{
    public Animator animator;
    Rigidbody2D rb;
    float speed;
    public float dashTime = 0.5f;
    public float dashReloadTime = 2f;
    public bool isDash = false;

    void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        speed = GetComponent<Stats>().speed;
    }

    void Update()
    {
        if (!isDash)
        { 
            Dash();
        }
    }

    public void Dash()
    {
        animator.SetBool("isDash", true);
        StartCoroutine(DashTimer());
        rb.velocity = new Vector2(speed, rb.velocity.y);
        animator.SetBool("isDash", false);
    }

    IEnumerator DashTimer()
    {
        isDash = true;
        yield return new WaitForSeconds(dashTime);
        StartCoroutine(DashReloadTimer());
    }

    IEnumerator DashReloadTimer()
    {
        rb.velocity = new Vector2(0, rb.velocity.y);
        yield return new WaitForSeconds(dashReloadTime);
        isDash = false;
    }
}
