using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Root : MonoBehaviour
{
    public int damage;
    public float speed;
    private Animator animator;
    public float spawnY;
    private Rigidbody2D rb;
    public GameObject topPoint;
    public GameObject bottomPoint;

    private void Awake()
    {
        spawnY = transform.position.y;
    }
    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (animator.GetBool("isMoving"))
        {
            if ((speed > 0 && bottomPoint.transform.position.y < spawnY) || (speed < 0 && topPoint.transform.position.y > spawnY))
            {
                rb.velocity = new Vector2(0, speed);
            }
            else
            {
                rb.velocity = new Vector2(0, 0);
                animator.SetBool("isMoving", false);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!animator.GetBool("isWarning"))
            if (collision.tag == "Player")
                if (!collision.GetComponent<Stats>().isInvulnerable)
                    collision.GetComponent<Stats>().TakeDamage(damage);
    }
}
