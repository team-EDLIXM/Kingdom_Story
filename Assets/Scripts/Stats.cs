using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public int maxhealth;
    public int health;
    public float speed;
    public int dmg;
    public bool isInvinsible = false;

    private void Start()
    {
        health = maxhealth;
    }

    private void Update()
    {
        if (health <= 0)
            Destroy(gameObject);
    }

    public void TakeDamage(int dmg)
    {
        health -= dmg;
        GetComponent<Animator>().SetBool("isHurt", true);
    }
}
