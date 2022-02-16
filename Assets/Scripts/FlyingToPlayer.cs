using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingToPlayer : MonoBehaviour
{
    private bool playerIsNear = false; // player is in trigger
    private Rigidbody2D rb;
    private GameObject player;
    private Stats stats;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
        stats = GetComponent<Stats>();
    }

    private void Update()
    {
        if (playerIsNear)
        {
            rb.velocity = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y) * stats.speed;
        }
    }

    private void FixedUpdate()
    {
        if (playerIsNear && !CheckFacingPlayer())
            Flip();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            playerIsNear = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            playerIsNear = false;
    }

    private bool CheckFacingPlayer()
    {
        bool playerFromLeft = player.transform.position.x < transform.position.x;
        bool playerFromRight = !playerFromLeft;
        return (playerFromLeft && transform.right.x < 0) || (playerFromRight && transform.right.x > 0);
    }

    private void Flip()
    {
        float y = transform.rotation.y;
        if (y == 0)
            y = 180;
        else
            y = 0;
        transform.rotation = Quaternion.Euler(0, y, 0);
    }
}