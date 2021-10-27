using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class buff : MonoBehaviour
{
    public hero Hero;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(this.gameObject);
        int jj = 1;
        FindObjectOfType<hero>().extraJumpValue = jj;
    }
}
