using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnKey : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            AudioManager.instance.PlaySFX(4);
            GameObject.Find("Canvas").GetComponentInChildren<KeyController>().KeysCountUp();
            print("Key was picked");
            Destroy(gameObject);
        }
    }
}
