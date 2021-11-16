using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float destroyTime;
    private void Start()
    {
        Destroy(gameObject, destroyTime);
    }

    private void OnTriggerEnter2D(Collider2D hitObject)
    {
        if (!hitObject.isTrigger)
            Destroy(gameObject);
    }
}
