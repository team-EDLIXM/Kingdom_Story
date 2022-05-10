using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonMiddleFire : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            collision.GetComponent<Stats>().TakeDamage(GameObject.Find("Dragon").GetComponent<Dragon>().damage);
    }
}
