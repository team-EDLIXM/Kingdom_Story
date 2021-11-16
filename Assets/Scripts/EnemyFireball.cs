using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFireball : MonoBehaviour
{
    public float speed = 5f;
    new private Rigidbody2D rigidbody;


    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        var directionOfEnemy = FindObjectOfType<RunningAwayEnemy>().transform.right;
        rigidbody.velocity =  directionOfEnemy * speed;
    }

    private void OnTriggerEnter2D(Collider2D hitObject)
    {
        if (hitObject.gameObject.tag != "Enemy")
            Destroy(gameObject);
    }
}
