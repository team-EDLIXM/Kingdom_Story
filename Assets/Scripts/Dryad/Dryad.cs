using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dryad : MonoBehaviour
{
    GameObject player;
    private int damage;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
        damage = GetComponent<Stats>().dmg;
    }

    private void Update()
    {
        if (!CheckFacingPlayer())
            Flip();
    }
    private bool CheckFacingPlayer()
    {
        bool playerFromLeft = player.transform.position.x < transform.position.x;
        bool playerFromRight = !playerFromLeft;
        return (playerFromLeft && transform.right.x > 0) || (playerFromRight && transform.right.x < 0);
    }

    private void Flip()
    {
        float y = transform.rotation.y;
        if (y == 0)
            y = 180;
        else
            y = 0;
        transform.rotation = Quaternion.Euler(0, y, 0);
    }

    public void Attack()
    {
        if (GetComponentInChildren<HitZoneCheck>().playerIsInTrigger)
            player.GetComponent<Stats>().TakeDamage(damage);
    }
}
