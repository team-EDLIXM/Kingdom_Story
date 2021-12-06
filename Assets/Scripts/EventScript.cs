using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventScript : MonoBehaviour
{

    public GameObject PMenu;

    void Start()
    {
        
    }

     void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            if (Time.timeScale == 1.0f)
            { 
                Time.timeScale = 0.0f;
                PMenu.SetActive(true);
            }
            else
            {
                Time.timeScale = 1.0f;
                PMenu.SetActive(false);
            }
        }
    }
    
}
