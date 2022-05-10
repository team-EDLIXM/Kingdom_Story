using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeyController : MonoBehaviour
{
    private TMP_Text text;
    public int Keys_Count = 0;
    private int keys_count_gain = 1;

    public void KeysCountUp()
    {
        Keys_Count += keys_count_gain;
    }

    public void Start()
    {
        text = GetComponent<TMP_Text>();
    }

    public void Update()
    {
        text.text = Keys_Count.ToString();
    }
}
