using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class buff : MonoBehaviour
{
    private bool triggerred = false;
    public String BuffTag;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        
        Destroy(this.gameObject);
        if (BuffTag == "DJump")
        {
            FindObjectOfType<hero>().extraJumpValue = 1;
            FindObjectOfType<NotifyScript>().Notify("Вы получили навык двойного прыжка, нажмите: SPACE+SPACE");
        }
        if (BuffTag == "Fireball")
        {
            FindObjectOfType<HeroAttack>().FireballUnlocked = true;
            FindObjectOfType<NotifyScript>().Notify("Теперь вы можете атаковать магией, нажмите: ПКМ");
        }
    }

}
