using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : MonoBehaviour
{
    public int damage;
    public int headLeftHealth;
    public int headMiddleHealth;
    public int headRightHealth;
    public bool isInvulnerable = false;
    public float InvulnerableTime = 0.5f;

    private void Update()
    {
        
    }

    public void TakeDamage(int head, int dmg)
    {
        if (!isInvulnerable)
        {
            switch (head)
            {
                case 1: 
                    headLeftHealth -= dmg;
                    break;
                case 2:
                    headMiddleHealth -= dmg;
                    break;
                case 3:
                    headRightHealth -= dmg;
                    break;
            }
            StartCoroutine(Invulnerability());
        }
    }
    private IEnumerator Invulnerability()
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

    public void HeadLeftHit()
    {
        if (GameObject.Find("headLeft").GetComponent<playerCheck>().playerIsInTrigger)
            GameObject.Find("Player").GetComponent<Stats>().TakeDamage(damage);
    }
    public void HeadMiddleHit()
    {
        if (GameObject.Find("headMiddle").GetComponent<playerCheck>().playerIsInTrigger)
            GameObject.Find("Player").GetComponent<Stats>().TakeDamage(damage);
    }
    public void HeadRightHit()
    {
        if (GameObject.Find("headRight").GetComponent<playerCheck>().playerIsInTrigger)
            GameObject.Find("Player").GetComponent<Stats>().TakeDamage(damage);
    }
}
