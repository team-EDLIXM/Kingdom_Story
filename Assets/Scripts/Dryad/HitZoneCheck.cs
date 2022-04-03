using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitZoneCheck : MonoBehaviour
{
    public bool playerIsInTrigger = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerIsInTrigger = true;
            if (GetComponentInParent<Animator>().GetBool("idle"))
                GetComponentInParent<Animator>().SetTrigger("slapAttack");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerIsInTrigger = false;
            GetComponentInParent<Animator>().SetBool("slapAttack", false);
        }
    }
}
