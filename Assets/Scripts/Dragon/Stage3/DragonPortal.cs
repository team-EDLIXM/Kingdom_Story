using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonPortal : MonoBehaviour
{
    //public bool playerIsInTrigger;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (!collision.GetComponent<Stats>().isInvulnerable)
                collision.GetComponent<Stats>().TakeDamage(GameObject.Find("Dragon").GetComponent<Dragon>().damage);
            //else
            //    playerIsInTrigger = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (!collision.GetComponent<Stats>().isInvulnerable)
                collision.GetComponent<Stats>().TakeDamage(GameObject.Find("Dragon").GetComponent<Dragon>().damage);
            //else
            //    playerIsInTrigger = false;
        }
    }

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.tag == "Player")
    //    {
    //        playerIsInTrigger = false;
    //    }
    //}
}