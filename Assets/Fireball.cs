using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    [SerializeField] private LayerMask enemy;

    public float speed = 5;
    public float destroyTime;
    public int dmg = 1;

    void Start()
    {
        Destroy(gameObject, destroyTime);
    }

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == enemy.value)
        {
            other.GetComponent<Stats>().TakeDamage(dmg);
        }

        Destroy(gameObject);
    }
}
