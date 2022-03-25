using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitZoneCheck : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (GetComponentInParent<Animator>().GetBool("idle"))
                GetComponentInParent<Animator>().SetTrigger("slapAttack");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GetComponentInParent<Animator>().SetBool("slapAttack", false);
        }
    }
}
