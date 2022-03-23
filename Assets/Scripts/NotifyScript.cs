using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NotifyScript : MonoBehaviour
{
    private TMP_Text txt;
    void Start()
    {
        txt = GetComponent<TMP_Text>();
    }

    void Update()
    {
        
    }

    public void Notify(string n)
    {
        txt.text = n;
        Invoke("Clear", 3.0f);
    }
    public void Clear()
    {
        txt.text = "";
    }
}
