using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public int maxhealth;
    public int health;
    public float speed;
    public int dmg;

    private void Start()
    {
        health = maxhealth;
    }

    private void Update()
    {
        if (health <= 0)
            Destroy(gameObject);
    }
}
