using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class death : MonoBehaviour
{
    Vector3 spawn = new Vector3(-13.84f, -3.52f, 0);


    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.transform.position = spawn;
        }
        
        
        
        
    }
}
