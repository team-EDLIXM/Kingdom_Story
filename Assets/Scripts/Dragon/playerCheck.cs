using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCheck : MonoBehaviour
{
    public bool playerIsInTrigger;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (!collision.GetComponent<Stats>().isInvulnerable)
                playerIsInTrigger = true;
            else
                playerIsInTrigger = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerIsInTrigger = false;
        }
    }
}
