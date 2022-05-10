using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    [SerializeField] private LayerMask enemy;

    public float speed = 5;
    public float destroyTime;
    private int dmg = 1;

    void Start()
    {
        Destroy(gameObject, destroyTime);
        dmg = GameObject.Find("Player").GetComponent<Stats>().dmg;
    }

    void Update()
    {
        /*transform.Translate(Vector2.right * speed * Time.deltaTime);*/
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((enemy.value & (1 << other.gameObject.layer)) > 0)
        {
            other.GetComponent<Stats>().TakeDamage(dmg);
            Destroy(gameObject);
        }
    }
}
