using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stats : MonoBehaviour
{
    private Animator anim;
    public int maxhealth;
    public int health;
    public float speed;
    public int dmg;
    public bool isInvulnerable = false;
    public float InvulnerableTime = 0.5f;
    
    public AudioSource sound;
    private void Start()
    {
        health = maxhealth;
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (health <= 0)
            if(gameObject!= null)
                gameObject.SetActive(false);
    }

    /// <summary>
    /// ��������� �����
    /// </summary>
    public void TakeDamage(int value)
    {
        if (!isInvulnerable)
        {
            if (this.tag == "Player")
            {
                //anim.SetTrigger("IsTakingDamage");

                /*var sr = this.GetComponent<SpriteRenderer>();

                sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 1f);*/
                StartCoroutine(InvulnerabilityP());
            }
            else
            {
                anim.SetTrigger("IsTakingDamage");
                health -= value;
                sound.Play();
                if (health <= 0)
                {
                    //anim.Play("Die");

                    //Destroy(gameObject);
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
        isInvulnerable = true;
        yield return new WaitForSeconds(InvulnerableTime);
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
