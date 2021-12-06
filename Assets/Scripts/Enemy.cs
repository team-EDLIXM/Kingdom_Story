using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int health = 3;

    public void TakeDamage(int damage) 
    {
        Knockback();
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(Vector2.left  * Time.deltaTime);
    }

    void Die() 
    {
        Destroy(gameObject);
    }

    void Knockback() 
    {
        transform.Translate(Vector2.right /10);
    }
}
