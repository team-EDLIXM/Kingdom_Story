using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    public int Keys_Count = 0;
    private int keys_count_gain = 1;

    public void KeysCountUp()
    {
        Keys_Count += keys_count_gain;
    }
}
