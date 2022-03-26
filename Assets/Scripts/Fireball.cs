using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float destroyTime;
    public int dmg;
    private void Start()
    {
        Destroy(gameObject, destroyTime);
    }

    private void OnTriggerEnter2D(Collider2D hitObject)
    {
        if (!hitObject.isTrigger)
        {
            switch (hitObject.tag)
            {
                case "Enemy":
                    if (!hitObject.GetComponent<Stats>().isInvulnerable)
                        hitObject.GetComponent<Stats>().TakeDamage(dmg);
                    break;
                case "Player":
                    if (!hitObject.GetComponent<Stats>().isInvulnerable)
                        hitObject.GetComponent<Stats>().TakeDamage(dmg);
                    break;
            }
            Destroy(gameObject);
        }
    }
}
