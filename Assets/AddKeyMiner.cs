using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddKeyMiner : MonoBehaviour
{
    private bool isGetKey = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isGetKey)
        {
            AudioManager.instance.PlaySFX(4);
            GameObject.Find("Canvas").GetComponentInChildren<KeyController>().KeysCountUp();
            isGetKey = true;
        }
    }
}
