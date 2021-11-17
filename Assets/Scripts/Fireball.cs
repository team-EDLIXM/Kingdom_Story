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
                    hitObject.GetComponent<Stats>().health -= dmg;
                    break;
                case "Player":
                    hitObject.GetComponent<Stats>().health -= dmg;
                    break;
            }
            Destroy(gameObject);
        }
    }
}
