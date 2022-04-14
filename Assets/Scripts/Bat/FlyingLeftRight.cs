using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingLeftRight : MonoBehaviour
{

    private Rigidbody2D rb;
    private Stats stats;

    public float distance;
    private float startPoint;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        stats = GetComponent<Stats>();
        startPoint = transform.position.x;
    }


    void Update()
    {
        float nextPosition = transform.position.x + stats.speed * transform.right.x;
        if ((transform.right.x < 0 && startPoint - distance <= nextPosition)
            || (transform.right.x > 0 && startPoint + distance >= nextPosition))
            rb.velocity = transform.right * stats.speed;
        //transform.position = Vector3.MoveTowards(transform.position, transform.position + new Vector3(transform.right.x, 0, 0), stats.speed * Time.deltaTime);
        else
            Flip();
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<Stats>().TakeDamage(stats.dmg);
        }
    }
}
