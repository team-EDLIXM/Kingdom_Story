using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public int damage;
    private Rigidbody2D rb;
    public LayerMask WhatIsSolid;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

   
    void Update()
    {

        rb.velocity = transform.right * speed;
        //transform.Translate(Vector2.right * speed );
    }
    public void OnTriggerEnter2D(Collider2D hitInfo)
    {
        
        Enemy en = hitInfo.GetComponent<Enemy>();
        
        if (en != null)
        {
            en.TakeDamage(damage);
        }
        if (hitInfo.transform.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }

    }
}
