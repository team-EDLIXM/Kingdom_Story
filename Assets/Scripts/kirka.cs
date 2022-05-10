using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kirka : MonoBehaviour
{
    public GameObject fdialogue;
    public GameObject sdialogue;
    public bool k;
    public void Start()
    {
        k = false;
    }
    void Update()
    {
        if (k == true)
        {
            fdialogue.SetActive(false);
            sdialogue.SetActive(true);
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            k = true;
        }
    }
}
