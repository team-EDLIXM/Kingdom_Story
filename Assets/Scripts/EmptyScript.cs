using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int a = 10;
        a = MultyplyBy2(a);

        Debug.Log(a);
        
        
        
    }

    int MultyplyBy2(int n)
    {
        return n * 2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
