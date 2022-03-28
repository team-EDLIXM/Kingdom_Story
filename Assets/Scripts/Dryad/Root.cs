using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Root : MonoBehaviour
{
    public int damage;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!animator.GetBool("isWarning"))
            if (collision.tag == "Player")
                if (!collision.GetComponent<Stats>().isInvulnerable)
                    collision.GetComponent<Stats>().TakeDamage(damage);
    }
}
