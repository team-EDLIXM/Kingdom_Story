using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventScript : MonoBehaviour
{
    void Start()
    {
        
    }

     void Update()
    {
        if (Input.GetKey("escape")) // ���� ����� Esc
            SceneManager.LoadScene("MainMenu");  // ����� � ����

    }
    
}
