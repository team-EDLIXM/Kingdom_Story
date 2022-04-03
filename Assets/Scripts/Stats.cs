using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    private Animator anim;
    public int maxhealth;
    public int health;
    public float speed;
    public int dmg;
    public bool isInvulnerable = false;
    public float InvulnerableTime = 0.5f;
    private void Start()
    {
        health = maxhealth;
        anim = GetComponent<Animator>();
    }

    /// <summary>
    /// Получение урона
    /// </summary>
    public void TakeDamage(int value)
    {
        if (!isInvulnerable)
        {
            anim.SetTrigger("isTakingDamage");
            if (this.tag == "Player")
            {
                health -= value;
                StartCoroutine(InvulnerabilityP());
            }
            else
            {
                health -= value;

                if (health <= 0)
                {
                    //anim.Play("Die");

                    Destroy(gameObject);
                }
                else
                {
                    StartCoroutine(Invulnerability());
                }
            }
        }
    }

    private IEnumerator Invulnerability()
    {
        isInvulnerable = true;
        speed /= 4;
        yield return new WaitForSeconds(InvulnerableTime);
        speed *= 4;
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

    //public void Die()
    //{
    //    anim.SetTrigger("IsDead");
    //    GetComponent<Rigidbody2D>().simulated = false;
    //    GetComponent<Collider2D>().enabled = false;
    //    this.enabled = false;
    //}
}
