using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonLightning : MonoBehaviour
{
    public int dmg;

    private void OnTriggerEnter2D(Collider2D hitObject)
    {
        if (!hitObject.isTrigger)
        {
            if (hitObject.tag == "Player")
            {
                if (!hitObject.GetComponent<Stats>().isInvulnerable)
                    hitObject.GetComponent<Stats>().TakeDamage(dmg);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
