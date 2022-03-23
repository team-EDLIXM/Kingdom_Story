using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public Animator anim;
    public int maxhealth;
    public int health;
    public float speed;
    public int dmg;
    public bool isInvulnerable = false;
    public float InvulnerableTime = 0.5f;

    private void Start()
    {
        health = maxhealth;
    }

    private void Update()
    {
        if (health <= 0)
            Destroy(gameObject);
    }

    /// <summary>
    /// ��������� �����
    /// </summary>
    public void TakeDamage(int value)
    {
        if (!isInvulnerable)
        {
            anim.SetTrigger("IsTakingDamage");
            health -= value;
            StartCoroutine(Invulnerability());
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
}
