using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed : MonoBehaviour
{
    public float destroyTime;
    public int dmg;
    private void Start()
    {
        Destroy(gameObject, destroyTime);
    }

    private void OnTriggerEnter2D(Collider2D hitObject)
    {
        if (!hitObject.isTrigger && hitObject.tag == "Player")
        {
            if (!hitObject.GetComponent<Stats>().isInvulnerable)
                hitObject.GetComponent<Stats>().TakeDamage(dmg);
            Destroy(gameObject);
        }
    }
}
