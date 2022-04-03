using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MMScript : MonoBehaviour
{
    private JsonSaveSystem _sSystem;
    
    public GameObject _contBut;
    private void Awake()
    {
        _sSystem = new JsonSaveSystem();
        _contBut.SetActive(!_sSystem.Load().isNewGame);
    }

    public void Continue()
    {
        SceneManager.LoadScene("Forest");
        /*
        if(!_sSystem.Load().isNewGame)
            SceneManager.LoadScene("Forest");
        else
        {
            _contBut.SetActive(false);
        }*/
    }
    public void NewGame()
    {
        var sd = new SaveData
        {
            isNewGame = false
        };
        _sSystem.Save(sd);
        SceneManager.LoadScene("Forest");
    }
    public void Quit() 
    {
        Application.Quit();
    }
}
