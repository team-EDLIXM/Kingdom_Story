using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonMagicalSphere : MonoBehaviour
{
    public int dmg;
    private void Start()
    {
        var pos = this.transform.position;
        var target = GameObject.FindGameObjectWithTag("Player").transform.position;
        var rb = this.GetComponent<Rigidbody2D>();
        float time = 1f;
        Vector2 speed = (new Vector2(target.x, target.y) - new Vector2(pos.x, pos.y) - Physics2D.gravity * time * time / 2f) / time;

        rb.velocity = (speed);
    }

    private void OnTriggerEnter2D(Collider2D hitObject)
    {
        if (!hitObject.isTrigger)
        {
            if (hitObject.tag == "Player")
            {
                if (!hitObject.GetComponent<Stats>().isInvulnerable)
                    hitObject.GetComponent<Stats>().TakeDamage(dmg);
            }
            Destroy(gameObject);
        }
    }
}
