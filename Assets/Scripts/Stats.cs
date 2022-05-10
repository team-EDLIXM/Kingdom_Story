using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D _rb;
    public int maxhealth;
    public int health;
    public float speed;
    public int dmg;
    public bool isInvulnerable = false;
    public float InvulnerableTime = 0.5f;
    public Vector2 PushingForce = new Vector2(0.5f,0.5f);
    public float PushingTime = 0.5f;
    public bool isPushed;
    public bool freezeHP = false;
    public Vector2 velocity;
    private void Start()
    {
        health = maxhealth;
        anim = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// Получение урона
    /// </summary>
    public void TakeDamage(int value)
    {
        if (!isInvulnerable)
        {
            if (!freezeHP) health -= value;
            anim.SetTrigger("isTakingDamage");

            if (this.tag == "Player")
            {
                StartCoroutine(InvulnerabilityP());
            }
            else
            {
                StartCoroutine(Invulnerability());
            }
        }
    }

    private Vector2 pushDir;
    public void Update()
    {
        if (_rb != null) velocity = _rb.velocity;
        if (_rb != null && isPushed)
            if (tag == "Player")
                GetComponent<hero>().otherVelocity = pushDir;
            else 
                _rb.velocity = new Vector2(pushDir.x , pushDir.y);
                //_rb.velocity = new Vector2(_rb.velocity.x + pushDir.x , _rb.velocity.y + pushDir.y);

    }
    public void Push(Vector2 direction)
    {
        if (!isPushed)
        {
            direction.Normalize();
            pushDir = direction * PushingForce;
            StartCoroutine(Pushing());
        }
    }

    private IEnumerator Pushing()
    {
        isPushed = true;
        yield return new WaitForSeconds(PushingTime);
        isPushed = false;
    }
    
    private IEnumerator Invulnerability()
    {
        float tmp = speed;
        isInvulnerable = true;
        //speed /= 4;

        yield return new WaitForSeconds(InvulnerableTime);
        
        //speed *= 4;
        isInvulnerable = false;
        
    }

    private IEnumerator InvulnerabilityP()
    {
        this.GetComponent<SpriteRenderer>().color = new Color(
            this.GetComponent<SpriteRenderer>().color.r,
            this.GetComponent<SpriteRenderer>().color.g,
            this.GetComponent<SpriteRenderer>().color.b, 0.5f);
        isInvulnerable = true;
        yield return new WaitForSeconds(InvulnerableTime);
        this.GetComponent<SpriteRenderer>().color = new Color(
            this.GetComponent<SpriteRenderer>().color.r,
            this.GetComponent<SpriteRenderer>().color.g,
            this.GetComponent<SpriteRenderer>().color.b, 1f);
        isInvulnerable = false;
        
    }

    private void CheckDeath()
    {
        if (health <= 0)
        {
            speed = 0;
            dmg = 0;
            anim.SetTrigger("isDead");
        }
    }

    private void onDead()
    {
        Destroy(gameObject);
    }
    //public void Die()
    //{
    //    anim.SetTrigger("IsDead");
    //    GetComponent<Rigidbody2D>().simulated = false;
    //    GetComponent<Collider2D>().enabled = false;
    //    this.enabled = false;
    //}
}
