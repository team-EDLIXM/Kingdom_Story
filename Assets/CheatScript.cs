using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CheatScript : MonoBehaviour
{
    public TMP_InputField iField;

    public Toggle toggle;

    private HolderScript holder;
    
    private void Start()
    {
        holder = FindObjectOfType<HolderScript>();
        iField.text = "" + holder.Damage;
        toggle.isOn = holder.areFreeze;
    }

    public void DmgChanged()
    {
        var num = Int32.Parse(iField.text);
        if (num < 0)
            iField.text = "0";
        else if (num > 100)
            iField.text = "100";

        holder.Damage = num;
        holder.ApplyChanges();
    }
    
    public void FreezeHPChanged()
    {
        holder.areFreeze = toggle.isOn;
        holder.ApplyChanges();
    }
}
