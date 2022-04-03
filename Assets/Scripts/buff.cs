using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class buff : MonoBehaviour
{


    private bool triggerred = false;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(this.gameObject);
        FindObjectOfType<hero>().extraJumpValue = 1;
        FindObjectOfType<NotifyScript>().Notify("Вы получили навык двойного прыжка, нажмите: SPACE+SPACE");
    }

}
