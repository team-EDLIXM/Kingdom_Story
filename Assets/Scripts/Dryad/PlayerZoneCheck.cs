using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerZoneCheck : MonoBehaviour
{
    public bool playerIsInTrigger = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerIsInTrigger = true;
            GetComponentInChildren<Animator>().Play("Dryad_Idle");
            GetComponentInChildren<Animator>().enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerIsInTrigger = false;
            GetComponentInChildren<Animator>().enabled = false;
        }
    }
}
