using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CaveTP : MonoBehaviour
{


    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.transform.position = new Vector3(85.37694f, 1.503887f, 0f);
        }
    }
}
