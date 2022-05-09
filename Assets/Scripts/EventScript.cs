using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventScript : MonoBehaviour
{

    public GameObject PMenu;
    
    public GameObject Tutorial;

    private bool MenuIsActive = false;
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            if (Time.timeScale == 1.0f)
            { 
                Time.timeScale = 0.0f;
                PMenu.SetActive(true);
                MenuIsActive = true;
            }
            else
            {
                Time.timeScale = 1.0f;
                PMenu.SetActive(false);
                Tutorial.SetActive(false);
                MenuIsActive = false;
            }
        }
        
        if (!MenuIsActive && Input.GetKeyDown("tab"))
        {
            if (Time.timeScale == 1.0f)
            { 
                Time.timeScale = 0.0f;
                Tutorial.SetActive(true);
            }
            else
            {
                Time.timeScale = 1.0f;
                Tutorial.SetActive(false);
            }
        }
    }
    
}
