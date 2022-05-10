using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : MonoBehaviour
{

    private Rigidbody2D rb;
    private Stats stats;

    public float distance;
    private float startPoint;
    private int direction;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        stats = GetComponent<Stats>();
        startPoint = transform.position.y;
        direction = 1;
    }


    void Update()
    {
        float nextPosition = transform.position.y + stats.speed * direction;
        if ((direction < 0 && startPoint - distance <= nextPosition) || (direction > 0 && startPoint + distance >= nextPosition))
            rb.velocity = direction * transform.up * stats.speed;
        //transform.position = Vector3.MoveTowards(transform.position, transform.position + new Vector3(transform.right.x, 0, 0), stats.speed * Time.deltaTime);
        else
            direction *= -1;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            var otherStats = other.GetComponent<Stats>();
            otherStats.TakeDamage(stats.dmg);
            var v = new Vector2(other.transform.position.x - transform.position.x,
                other.transform.position.y - transform.position.y);
            v.Normalize();
            otherStats.Push(v);
        }
        direction *= -1;
    }
}
