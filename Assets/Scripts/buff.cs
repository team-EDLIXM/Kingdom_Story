using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class buff : MonoBehaviour
{
    

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(this.gameObject);
        FindObjectOfType<hero>().extraJumpValue = 1;
    }
}
