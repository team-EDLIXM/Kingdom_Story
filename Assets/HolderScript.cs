using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HolderScript : MonoBehaviour
{
    public bool areFreeze = false;
    public int Damage = 1;

    public static HolderScript instance; 
    private void Awake()
    {
        print(SceneManager.GetActiveScene().name);
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else 
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
       
    }

    public void DestroyThis()
    {
        Destroy(gameObject);
    }

    public void ApplyChanges()
    {
        var heroStat = GameObject.FindGameObjectWithTag("Player").GetComponent<Stats>();
        heroStat.dmg = Damage;
        heroStat.freezeHP = areFreeze;
    }

}
