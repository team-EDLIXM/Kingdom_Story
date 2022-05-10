using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed : MonoBehaviour
{
    public LayerMask borders;
    public float speed = 5;
    public float destroyTime;
    public int dmg = 1;

    void Start()
    {
        Destroy(gameObject, destroyTime);
    }

    void Update()
    {
        transform.Translate(-Vector2.right * speed * Time.deltaTime);
        var filter = new ContactFilter2D().NoFilter();
        filter.SetLayerMask(borders);
        var others = new List<Collider2D>();
        GetComponent<Collider2D>().OverlapCollider(filter, others);
        if (others.Count != 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            var otherStats = other.GetComponent<Stats>();
            otherStats.TakeDamage(dmg);
            var v = new Vector2(other.transform.position.x - transform.position.x,
                other.transform.position.y - transform.position.y);
            v.Normalize();
            otherStats.Push(v);
            Destroy(gameObject);
        }
    }
}
