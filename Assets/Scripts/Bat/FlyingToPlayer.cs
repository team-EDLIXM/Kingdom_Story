using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingToPlayer : MonoBehaviour
{
    
    private Rigidbody2D rb;
    private GameObject player;
    private Stats stats;
    private PlayerCheck playerCheck;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
        stats = GetComponent<Stats>();
        playerCheck = GetComponentInParent<PlayerCheck>();
    }

    private void Update()
    {
        //float dx = player.transform.position.x - transform.position.x;
        //float dy = player.transform.position.y - transform.position.y;
        float x = player.transform.position.x;
        float y = player.transform.position.y;
        if (playerCheck.playerIsNear)
        {
            //rb.velocity = new Vector2(dx, dy + 2) * stats.speed;
            transform.parent.position = Vector2.MoveTowards(transform.parent.position, new Vector2(x, y), stats.speed*Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<Stats>().TakeDamage(stats.dmg);
        }
    }

    /*private void FixedUpdate()
    {
        if (playerCheck.playerIsNear && !CheckFacingPlayer())
            Flip();
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
    }*/
}